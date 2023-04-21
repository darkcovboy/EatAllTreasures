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
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _moneyEarnedText;
    [SerializeField] private Button _button;
    [SerializeField] private int _nextLevel;

    private delegate void CloseCallback(bool onCloseCallback);

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

    private void OnEnable()
    {
        _button.interactable = false;

        if (PlayerAccount.IsAuthorized == true)
        {
            Leaderboard.SetScore("EatAllTreusersLeaderbord", _player.Money);
        }

        foreach (var obj in _objectsToClose)
        {
            obj.SetActive(false);
        }

        StartCoroutine(FillMoney(_player.EndMoney));
    }

    private IEnumerator FillMoney(int end)
    {
        for(int i= 0; i <= end; i+=PlayerPrefs.GetInt("Level"))
        {
            _moneyEarnedText.text = i.ToString();
            yield return null;
        }

        _button.interactable = true;
    }
}
