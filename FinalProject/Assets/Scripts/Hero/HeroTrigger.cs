using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(AudioManager), typeof(InvincibilityBlink))]
public class HeroTrigger : MonoBehaviour
{
    [SerializeField] private Resources _resources;
    [SerializeField] private GameState _gameState;
    [SerializeField] private GameObject _heroExplodePrefab;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _invincibilityDuration = 3f;

    private bool _isInvincible = false;
    private AudioManager _audioManager;
    private InvincibilityBlink _blinker;

    public bool isDebugMode = false;
    private void Start()
    {
        _audioManager = GetComponent<AudioManager>();
        _blinker = GetComponent<InvincibilityBlink>();
    }

    public void AddEnergy(float count)
    {
        _resources.AddEnergy();
        _audioManager.PlaySound("Energy");
    }

    public void Damage()
    {
        if (!isDebugMode && !_isInvincible)
        {
            _audioManager.PlaySound("Explode");
            _resources.Damage();
            if (_resources.Hp <= 0)
            {
                _gameState.GameOver();
                _blinker.StopBlink();
                return;
            }
            StartCoroutine(nameof(BecomeInvincible));
        }
        
    }

    private IEnumerator BecomeInvincible()
    {
        _isInvincible = true;
        _blinker.StartBlink(_invincibilityDuration);
        yield return new WaitForSeconds(_invincibilityDuration);
        _isInvincible = false;
    }

    public void AddMoney(float count)
    {
        _resources.AddCoin();
        _audioManager.PlaySound("Coin");
    }

    public void LevelSucceeded()
    {
        _blinker.StopBlink();
        _animator.SetTrigger("victory");
        _audioManager.PlaySound("victory");
        _gameState.LevelSucceeded();
    }

    public void Explode()
    {
        Instantiate(_heroExplodePrefab, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }

    public void MoveTo(Vector3 posTarget)
    {
        if (posTarget.x < 0)
        {
            gameObject.GetComponent<HeroMovement>().MagnetTo(Vector2.left*Config.RowWidth);
        }
        if (posTarget.x > 0)
        {
            gameObject.GetComponent<HeroMovement>().MagnetTo(Vector2.right * Config.RowWidth);
        }
    }

    public void StopMove()
    {
        gameObject.GetComponent<HeroMovement>().StopMagnet();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (isDebugMode)
            {
                isDebugMode = false;
            }
            else
            {
                isDebugMode = true;
            }
        }
    }
}
