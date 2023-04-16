using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _levelSucceededPanel;
    [SerializeField] private Resources _resources;
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
        Progress.GetInstance().Info.Coins += _resources.Coins;
        Progress.GetInstance().Save();
    }

    public void Resume()
    {
        IsPlaying = true;
    }
}
