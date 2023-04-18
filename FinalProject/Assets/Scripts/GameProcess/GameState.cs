using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _levelSucceededPanel;
    [SerializeField] private Resources _resources;
    [SerializeField] private uint _currentLevel;
    public bool IsPlaying { get; private set; } = true;

    public void Pause()
    {
        IsPlaying = false;
        _pausePanel.SetActive(true);
    }

    public void GameOver()
    {
        IsPlaying = false;
        _gameOverPanel.SetActive(true);
    }

    public void LevelSucceeded()
    {
        IsPlaying = false;
        _levelSucceededPanel.SetActive(true);
        Progress instance = Progress.GetInstance();
        if (_currentLevel > instance.Info.LevelsPassed)
            instance.Info.LevelsPassed++;
        instance.Info.Coins += _resources.Coins;
        instance.Save();
    }

    public void Resume()
    {
        IsPlaying = true;
    }
}
