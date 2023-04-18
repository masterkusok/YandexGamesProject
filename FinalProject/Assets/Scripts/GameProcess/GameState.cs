using System.Collections;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _levelSucceededPanel;
    [SerializeField] private Resources _resources;
    [SerializeField] private HeroTrigger _heroTrigger;
    [SerializeField] private int _gameEndTimeout = 1;
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
        _heroTrigger.Explode();
        StartCoroutine(nameof(GameOverTimeoutRoutine));
    }

    public void LevelSucceeded()
    {
        IsPlaying = false;
        StartCoroutine(nameof(LevelSucceededTimeoutRoutine));
        Progress instance = Progress.GetInstance();
        if (_currentLevel > instance.Info.LevelsPassed)
            instance.Info.LevelsPassed++;
        instance.Info.Coins += _resources.Coins;
        instance.Save();
    }

    public void Resume()
    {
        IsPlaying = true;
        _pausePanel.SetActive(false);
    }

    private IEnumerator GameOverTimeoutRoutine()
    {
        yield return new WaitForSeconds(_gameEndTimeout);
        _pausePanel.SetActive(false);
        _gameOverPanel.SetActive(true);
    }

    private IEnumerator LevelSucceededTimeoutRoutine()
    {
        yield return new WaitForSeconds(_gameEndTimeout);
        _pausePanel.SetActive(false);
        _levelSucceededPanel.SetActive(true);
    }
}
