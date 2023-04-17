using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicSystem : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _listOfMusic;

    private AudioSource _audioSource;   
    private static MusicSystem _instance;

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
        _audioSource = GetComponent<AudioSource>();
        ChooseNextSong();
    }

    private void ChooseNextSong()
    {
        AudioClip clip = _listOfMusic[Random.Range(0, _listOfMusic.Count)];
        while(clip == _audioSource.clip)
            clip = _listOfMusic[Random.Range(0, _listOfMusic.Count)];
        PlaySong(clip);
    }

    private void PlaySong(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
        StartCoroutine(nameof(WaitForSongEnd), clip.length);
    }

    private IEnumerator WaitForSongEnd(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ChooseNextSong();
    }
}
