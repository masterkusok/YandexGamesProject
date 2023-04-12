using UnityEngine.Audio;
using UnityEngine;
using System;

[Serializable]
public class Sound
{
    public AudioClip Clip;
    public string Name;
    [Range(0f, 1f)] public float Volume;
    [Range(0f, 1f)] public float Pitch;

    private AudioSource _source;

    public void SetAudioSource(AudioSource source) => _source = source;

    public void Play() => _source.Play();

}
