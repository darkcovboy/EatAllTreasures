using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using System;
using UnityEngine.SceneManagement;

public class LoseField : MonoBehaviour
{
    [SerializeField] GameObject[] _objectsToClose;
    [SerializeField] OffAudio _offAudio;

    private AudioSource _audioSource;
    
    private void OnEnable()
    {
        foreach (var obj in _objectsToClose)
        {
            obj.SetActive(false);
        }

        _audioSource.Play();
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Restart()
    {
        Action<bool> action = OnCloseCallback;
        InterstitialAd.Show(OnOpenCallback, action);
    }

    private void OnOpenCallback()
    {
        _offAudio.TurnOffSounds();
        Time.timeScale = 0;
    }

    private void OnCloseCallback(bool onClose)
    {
        if (onClose == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }
}
