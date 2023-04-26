using UnityEngine;
using Lean;
using System.Collections;
using Lean.Localization;
using Agava.YandexGames;
using Agava.YandexGames.Samples;

public class LanguageDeterminate : MonoBehaviour
{
    [SerializeField] private LeanLocalization _leanLocalization;

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        StickyAd.Show();

        string language = YandexGamesSdk.Environment.i18n.lang;

        switch (language)
        {
            case "en":
                _leanLocalization.SetCurrentLanguage("English");
                break;
            case "tr":
                _leanLocalization.SetCurrentLanguage("Turkish");
                break;
            case "ru":
                _leanLocalization.SetCurrentLanguage("Russian");
                break;
        }
    }
}
