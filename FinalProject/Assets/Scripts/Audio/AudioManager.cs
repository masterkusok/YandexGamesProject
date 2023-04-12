using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<Sound> _sounds;
    [SerializeField] private float _soundCooldown = 0.1f;

    private bool _isOnCooldown = false;

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
        if (_isOnCooldown)
            return;

        //StartCooldown();

        Sound sound = _sounds.FirstOrDefault(s => s.Name.Equals(name));
        if(sound == null)
        {
            Debug.Log($"Sound {name} not found");
            return;
        }
        sound.Play();
    }

    private void StartCooldown() => StartCoroutine(nameof(CooldownTimer));

    private IEnumerator CooldownTimer()
    {
        _isOnCooldown = true;
        yield return new WaitForSeconds(_soundCooldown);
        _isOnCooldown = false;
    }
}
