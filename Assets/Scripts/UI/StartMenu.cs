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


        SceneManager.LoadScene(_levelToLoad);
    }
}
