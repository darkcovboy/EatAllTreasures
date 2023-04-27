using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class UpgradeElement : MonoBehaviour
{
    [SerializeField] protected float Cost;
    [SerializeField] protected float Enhancement;
    [SerializeField] protected float MaxEnhancement;

    protected Player Player;
    protected bool IsMaxEnhancement = false;
    protected bool IsRewardedVideoShowed = false;

    [SerializeField] private float CostIncrease;
    [SerializeField] private float CostInreaseMultiplier;
    [SerializeField] private TMP_Text Text;
    [SerializeField] private Button Button;
    [SerializeField] private Button AdButton;

    private AudioSource _audioSource;
    private MoneyCounter _moneyCounter;

    private readonly string _maxText = "Max";

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _moneyCounter = FindObjectOfType<MoneyCounter>();
        Player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        IsInteractable();
    }

    public float GetCost()
    {
        return Cost;
    }

    public bool GetMaxEnchancement()
    {
        return IsMaxEnhancement;
    }

    public virtual void Upgrade()
    {
        ChangeCost();
        _audioSource.Play();
    }

    public virtual void AdUpgrade()
    {
        IsRewardedVideoShowed = true;
        VideoAd.Show(OnOpenAd,null,OnCloseAd);
        ChangeCost();
        _audioSource.Play();
    }

    protected void ChangeCost()
    {
        Cost += CostIncrease;
        Cost *= CostInreaseMultiplier;
        Cost = Mathf.RoundToInt(Cost);
        ChangeText();
    }

    protected void ChangeVideoShowed()
    {
        IsRewardedVideoShowed = true;
    }

    protected void ChangeText()
    {
        Text.text = Cost.ToString();
    }

    private void OnCloseAd()
    {
        AudioListener.pause = true;
        Time.timeScale = 1;
    }

    private void OnOpenAd()
    {
        AudioListener.pause = false;
        Time.timeScale = 0;
    }

    private void IsInteractable()
    {
        if (!IsMaxEnhancement)
        {
            if (_moneyCounter.Money < Cost)
            {
                if (IsRewardedVideoShowed == false)
                {
                    AdButton.gameObject.SetActive(true);
                    Button.gameObject.SetActive(false);
                }
                else
                {
                    AdButton.gameObject.SetActive(false);
                    Button.gameObject.SetActive(true);
                }

                Button.interactable = false;
            }
            else
            {
                AdButton.gameObject.SetActive(false);
                Button.gameObject.SetActive(true);
                Button.interactable = true;
            }
        }
        else
        {
            AdButton.gameObject.SetActive(false);
            Button.gameObject.SetActive(true);
            Button.interactable = false;
            Text.text = _maxText;
        }
    }
}
