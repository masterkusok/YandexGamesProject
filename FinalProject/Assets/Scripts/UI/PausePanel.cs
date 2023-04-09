using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameState _gameState;

    private void Start()
    {
        _resumeButton.onClick.AddListener(ResumeHandler);
        _exitButton.onClick.AddListener(ExitHandler);
    }

    private void ResumeHandler()
    {
        gameObject.SetActive(false);
        _gameState.Resume();
    }

    private void ExitHandler()
    {
        gameObject.SetActive(false);
        _gameState.GameOver();
    }
}
