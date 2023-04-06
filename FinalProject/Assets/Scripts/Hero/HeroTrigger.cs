using UnityEngine;

public class HeroTrigger : MonoBehaviour
{
    [SerializeField] private Resources _resources;
    [SerializeField] private GameState _gameState;
    public void AddEnergy(float count)
    {
        _resources.AddEnegry();
        Debug.Log(_resources.Enegry);
    }

    public void damage()
    {
        _gameState.GameOver();
    }

    public void addMoney(float count)
    {
        _resources.AddCoin();
        Debug.Log(_resources.Coins);
    }

    public void LevelSucceeded()
    {
        _gameState.LevelSucceded();
    }

}
