using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using System;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsToClose;
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private TMP_Text _moneyEarnedText;
    [SerializeField] private Button _button;
    [SerializeField] private int _nextLevel;

    private readonly string _levelKey = "Level";

    private delegate void CloseCallback(bool onCloseCallback);

    private void OnEnable()
    {
        _button.interactable = false;

        foreach (var obj in _objectsToClose)
        {
            obj.SetActive(false);
        }

        StartCoroutine(FillMoney(_moneyCounter.EndMoney));
    }

    public void LoadLevel()
    {
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
            SceneManager.LoadScene(_nextLevel);
            AudioListener.pause = false;
            Time.timeScale = 1;
        }
    }

    private IEnumerator FillMoney(int end)
    {
        for(int i= 0; i <= end; i+=PlayerPrefs.GetInt(_levelKey))
        {
            _moneyEarnedText.text = i.ToString();
            yield return null;
        }

        _button.interactable = true;
    }
}
