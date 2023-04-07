using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool IsPlaying { get; private set; } = true;

    public void Pause()
    {
        IsPlaying = false;
    }

    public void GameOver()
    {
        IsPlaying = false;
    }

    public void LevelSucceeded()
    {
        IsPlaying = false;
    }

    public void Resume()
    {
        IsPlaying = true;
    }
}
