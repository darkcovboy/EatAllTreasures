using System.Collections;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StickyAdShow : MonoBehaviour
{
    private void Start()
    {
        StickyAd.Show();
    }

    private void OnDisable()
    {
        StickyAd.Hide();
    }
}
