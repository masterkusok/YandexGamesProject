using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelToggler : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(ButtonClickHandler);
    }

    private void ButtonClickHandler()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +
                               Convert.ToInt32(_button.gameObject.GetComponentInChildren<TMP_Text>().text));
    }

    public void SetButton(Button button)
    {
        _button = button;
    }
}
