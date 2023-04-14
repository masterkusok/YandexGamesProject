using UnityEngine;

[RequireComponent(typeof(Collider), typeof(AudioManager))]
public class HeroTrigger : MonoBehaviour
{
    [SerializeField] private Resources _resources;
    [SerializeField] private GameState _gameState;
    [SerializeField] private GameObject _heroExplodePrefab;
    [SerializeField] private Animator _animator;
    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = GetComponent<AudioManager>();
    }

    public void AddEnergy(float count)
    {
        _resources.AddEnergy();
        _audioManager.PlaySound("Energy");
    }

    public void Damage()
    {
        _gameState.GameOver();
    }

    public void AddMoney(float count)
    {
        _resources.AddCoin();
        _audioManager.PlaySound("Coin");
    }

    public void LevelSucceeded()
    {
        _animator.SetTrigger("victory");
        _audioManager.PlaySound("victory");
        _gameState.LevelSucceeded();
    }

    public void Explode()
    {
        _audioManager.PlaySound("Explode");
        Instantiate(_heroExplodePrefab, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }

    public void MoveTo(Vector3 posTarget)
    {
        if (posTarget.x < 0)
        {
            gameObject.GetComponent<HeroMovement>().MagnetTo(Vector2.left * Config.RowWidth);
        }
        if (posTarget.x > 0)
        {
            gameObject.GetComponent<HeroMovement>().MagnetTo(Vector2.left * Config.RowWidth);
        }
    }
}
