using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OffAudio : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSources;
    [SerializeField] private AudioSource _music;

    public bool IsSoundOn { get; set; }

    public bool IsMusicOn { get; set; }

    private void Start()
    {
        IsMusicOn = true;
        IsSoundOn = true;
    }

    public void TurnOnSounds()
    {
        foreach(var audioSource in _audioSources)
        {
            if(audioSource.enabled == false || IsSoundOn == true)
                audioSource.enabled = true;
        }

        if (_music.enabled == false || IsMusicOn == true)
            _music.enabled = true;
    }

    public void TurnOffSounds()
    {
        foreach (var audioSource in _audioSources)
        {
            if (audioSource.enabled == true || IsSoundOn == false)
                audioSource.enabled = false;
        }

        if (_music.enabled == true || IsMusicOn == false)
            _music.enabled = false;
    }
}
