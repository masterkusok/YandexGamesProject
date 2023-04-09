using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _restartButton.onClick.AddListener(RestartHandler);
        _exitButton.onClick.AddListener(ExitHandler);
    }

    private void RestartHandler()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ExitHandler()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
