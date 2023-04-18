using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioManager))]
public class HeroMovement : MonoBehaviour
{
    enum Position
    {
        Left = -1,
        Mid = 0,
        Right = 1
    }

    [SerializeField] private float _moveTime = 1f;
    private AudioManager _audioManager;

    private bool _magneted = false;

    private Position _position = Position.Mid;

    private Vector3 _targetPosition;

    private void Start()
    {
        _audioManager = gameObject.GetComponent<AudioManager>();
        _targetPosition = transform.position;
    }

    public void Turn(Vector2 direction)
    {
        if (_magneted)
            return;

        if (direction == Vector2.left && (_position == Position.Mid || _position == Position.Right))
        {
            _position--;
            StartMoving();
        }

        if (direction == Vector2.right && (_position == Position.Mid || _position == Position.Left))
        {
            _position++;
            StartMoving();
        }
    }

    public void MagnetTo(Vector2 targetPosition)
    {
        _magneted = true;
        _targetPosition = targetPosition;
        if (targetPosition == Vector2.left)
        {
            _position--;
        }

        if (targetPosition == Vector2.right)
        {
            _position++;
        }
        StopCoroutine(nameof(Move));
        StartCoroutine(nameof(Move));
    }

    private void StartMoving()
    {
        _audioManager.PlaySound($"Hop{Random.Range(1, 3)}");
        _targetPosition = new Vector3((int)_position, 0, 0) * Config.RowWidth;
        StopCoroutine(nameof(Move));
        StartCoroutine(nameof(Move));
    }

    private IEnumerator Move()
    {
        Vector3 startPos = transform.position;
        for (float i = 0f; i < _moveTime; i += Time.deltaTime * Config.RowWidth / _moveTime)
        {
            transform.position = Vector3.Lerp(startPos, _targetPosition, i);
            yield return null;
        }
        transform.position = _targetPosition;
    }

    public void StopMagnet()
    {
        _magneted = false;
    }
}
