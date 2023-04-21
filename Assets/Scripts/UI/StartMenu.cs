using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Agava.YandexGames;
using System;

public class StartMenu : MonoBehaviour
{
    private readonly string _lastLevel = "LastLevel";
    private readonly int _firstLevel = 1;
    private int _levelToLoad;

    private delegate void CloseCallback(bool onCloseCallback);

    public void LoadLevel()
    {
        if (PlayerPrefs.HasKey(_lastLevel))
            _levelToLoad = PlayerPrefs.GetInt(_lastLevel);
        else
            _levelToLoad = _firstLevel;

        Action<bool> action = OnCloseCallback;
        InterstitialAd.Show(OnOpenCallback, action);
    }

    private void OnOpenCallback()
    {
        AudioListener.pause = true;
        Time.timeScale = 0;
    }

    private void OnCloseCallback(bool onClose)
    {
        if (onClose == true)
        {
            SceneManager.LoadScene(_levelToLoad);
            AudioListener.pause = false;
            Time.timeScale = 1;
        }
    }
}
