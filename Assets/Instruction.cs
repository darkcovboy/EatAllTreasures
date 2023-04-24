using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Localization;
using Agava.YandexGames;
using Agava.YandexGames.Samples;

public class Instruction : MonoBehaviour
{
    [SerializeField] private LeanLocalizedTextMeshProUGUI _leanLocalizedTextMeshProUGUI;

    private readonly int _firstLevel = 1;
    private readonly string _levelKey = "Level";
    private readonly string _instructionDesktop = "InstructionDesktop";
    private readonly string _instructionOther = "InstructionOther";

    private void Start()
    {
        gameObject.SetActive(false);

        if (PlayerPrefs.GetInt(_levelKey) == _firstLevel)
        {
            gameObject.SetActive(true);

            if (Device.Type == Agava.YandexGames.DeviceType.Desktop)
            {
                _leanLocalizedTextMeshProUGUI.TranslationName = _instructionDesktop;
            }
            else
            {
                _leanLocalizedTextMeshProUGUI.TranslationName = _instructionOther;
            }
        }
    }
}
