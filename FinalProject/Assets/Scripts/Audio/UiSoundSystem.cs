using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioManager))]
public class UiSoundSystem : MonoBehaviour
{
    private static UiSoundSystem _instance;
    private AudioManager _audioManager;

    private void Awake()
    {

        if (_instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject())
            _audioManager.PlaySound("Click");
    }
}
