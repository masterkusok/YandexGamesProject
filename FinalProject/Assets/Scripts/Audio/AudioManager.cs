using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<Sound> _sounds;

    void Start()
    {
        foreach(Sound sound in _sounds)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();

            source.clip = sound.Clip;
            source.volume = sound.Volume;
            source.pitch = sound.Pitch;

            sound.SetAudioSource(source);
        }
    }

    public void PlaySound(string name)
    {
        Sound sound = _sounds.FirstOrDefault(s => s.Name.Equals(name));
        if(sound == null)
        {
            Debug.Log($"Sound {name} not found");
            return;
        }
        sound.Play();
    }
}
