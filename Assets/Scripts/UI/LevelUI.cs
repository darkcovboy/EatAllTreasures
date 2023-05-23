using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Localization;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private LeanPhrase _levelText;

    private readonly string _levelKey = "Level";
    private readonly string _exclamationPoint = "!";
    private readonly string _space = " ";

    private void Start()
    {
        /*
        _levelText = "asdasdasdasd";
        _levelText.text += _space + PlayerPrefs.GetInt(_levelKey).ToString() + _exclamationPoint;
        */
    }
}
