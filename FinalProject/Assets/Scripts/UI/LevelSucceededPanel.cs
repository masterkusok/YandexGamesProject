using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class LevelSucceededPanel : MonoBehaviour
{
    [SerializeField] private Resources _resources;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _scoreText.text = $"Ваш счет: {_resources.Coins.ToString()}";

        _nextButton.onClick.AddListener(NextHandler);
        _exitButton.onClick.AddListener(ExitHandler);
    }

    private void NextHandler()
    {
        gameObject.SetActive(false);
        //string path = @"./Assets/Levels/level.txt";
        //int nextLevel = 0;
        //using (StreamReader reader = new StreamReader(path))
        //{
        //    int.TryParse(reader.ReadLine(), out nextLevel);
        //}
        //nextLevel++;
        //using (StreamWriter writer = new StreamWriter(path))
        //{
        //    writer.Write(nextLevel);
        //}
        SceneManager.LoadScene($"Level {SceneManager.GetActiveScene().buildIndex + 1}");
    }

    private void ExitHandler()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
