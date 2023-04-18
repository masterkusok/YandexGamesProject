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
        var hpLevel = _resources.HpLevel;
        var bulletPowerLevel = _resources.BulletPowerLevel;
        _resources.KnockHpLevel();

        if (hpLevel == 0)
        {
            hpLevel = 1;
        }

        Debug.Log(hpLevel);

        Progress.GetInstance().Info.HpLevel = hpLevel;
        Progress.GetInstance().Info.BulletPowerLevel = bulletPowerLevel == 1 ? bulletPowerLevel : bulletPowerLevel - 1;
        Progress.GetInstance().Save();

        Debug.Log(Progress.GetInstance().Info.HpLevel);

        StartCoroutine(nameof(GameOverTimeoutRoutine));
    }

    public void LevelSucceeded()
    {
        IsPlaying = false;
        StartCoroutine(nameof(LevelSucceededTimeoutRoutine));
        Progress.GetInstance().Info.Coins += _resources.Coins;
        Progress.GetInstance().Save();
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
