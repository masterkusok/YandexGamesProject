using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioManager))]
public class UiSoundSystem : MonoBehaviour
{
    private static UiSoundSystem _instance;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GetComponent<AudioManager>();
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
        _audioManager = GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject())
            _audioManager.PlaySound("Click");
    }
}
