using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;

    private readonly string _levelKey = "Level";
    private readonly string _exclamationPoint = "!";
    private readonly string _space = " ";

    private void OnEnable()
    {
        _levelText.text += _space + PlayerPrefs.GetInt(_levelKey).ToString() + _exclamationPoint;
    }
}
