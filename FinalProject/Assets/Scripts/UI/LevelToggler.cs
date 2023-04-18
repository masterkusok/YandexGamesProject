using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class LevelToggler : MonoBehaviour
{
    private Button _button;


    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonClickHandler);
    }

    private void ButtonClickHandler()
    {
        string path = @"./Assets/Levels/level.txt";

        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.Write($"{Convert.ToInt32(_button.gameObject.GetComponentInChildren<TMP_Text>().text)}");
        }

        SceneManager.LoadScene(Convert.ToInt32(_button.gameObject.GetComponentInChildren<TMP_Text>().text));
    }

    public void SetButton(Button button)
    {
        _button = button;
    }
}
