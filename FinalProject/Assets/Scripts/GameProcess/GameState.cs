using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool IsPlaying { get; private set; } = true;

    public void Pause()
    {
        IsPlaying = false;
        // ... Логика для открытия всякого всякого
    }

    public void GameOver()
    {
        IsPlaying = false;
        // ... Логика для открытия всякого всякого
    }

    public void LevelSucceeded()
    {
        IsPlaying = false;
        // ... Логика для открытия всякого всякого
    }

    public void Resume()
    {
        IsPlaying = true;
        // ... Логика для закрытия всякого всякого
    }
}
