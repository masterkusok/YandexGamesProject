using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HeroTrigger : MonoBehaviour
{
    [SerializeField] private Resources _resources;
    [SerializeField] private GameState _gameState;
    public void AddEnergy(float count)
    {
        _resources.AddEnergy();
    }

    public void Damage()
    {
        _gameState.GameOver();
    }

    public void AddMoney(float count)
    {
        _resources.AddCoin();
    }

    public void LevelSucceeded()
    {
        _gameState.LevelSucceeded();
    }

}
