using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    private void Start()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].gameObject.GetComponentInChildren<TMP_Text>().text = (i + 1).ToString();
            _buttons[i].gameObject.GetComponentInChildren<LevelToggler>().SetButton(_buttons[i]);
        }
    }
}
