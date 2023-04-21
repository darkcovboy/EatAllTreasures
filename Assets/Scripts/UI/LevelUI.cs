using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;

    private void OnEnable()
    {
        _levelText.text += " " + PlayerPrefs.GetInt("Level").ToString() + "!";
    }
}
