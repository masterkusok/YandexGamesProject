using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    private void Awake()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            var button = _buttons[i];
            button.gameObject.GetComponentInChildren<TMP_Text>().text = (i + 1).ToString();
            button.gameObject.GetComponentInChildren<LevelToggler>().SetButton(button);
        }
    }
}
