using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private GameState _gameState;
    private void Update()
    {
        if (_gameState.IsPlaying)
        {
            Vector3 _targetPosition = _target.transform.position + _offset;
            Vector3 _smoothPosition = Vector3.Lerp(transform.position, _targetPosition, _speed * Time.deltaTime);
            transform.position = _smoothPosition;
        }
    }
}
