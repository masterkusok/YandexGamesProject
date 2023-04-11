using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HeroTrigger : MonoBehaviour
{
    [SerializeField] private Resources _resources;
    [SerializeField] private GameState _gameState;
    [SerializeField] private GameObject _heroExplodePrefab;

    public void AddEnergy(float count)
    {
        _resources.AddEnergy();
    }

    public void Damage()
    {
        _gameState.GameOver();
        Explode();
    }

    public void AddMoney(float count)
    {
        _resources.AddCoin();
    }

    public void LevelSucceeded()
    {
        _gameState.LevelSucceeded();
    }

    private void Explode()
    {
        Instantiate(_heroExplodePrefab, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }

    public void MoveTo(Vector3 posTarget)
    {
        if (posTarget.x < 0)
        {
            gameObject.GetComponent<HeroMovement>().Turn(Vector2.left);
        }
        if (posTarget.x > 0)
        {
            gameObject.GetComponent<HeroMovement>().Turn(Vector2.right);
        }
    }
}
