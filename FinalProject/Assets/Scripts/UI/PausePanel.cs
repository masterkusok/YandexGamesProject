using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _exitButton.onClick.AddListener(ExitHandler);
    }

    private void ExitHandler()
    {
        SceneManager.LoadScene(0);
    }
}
