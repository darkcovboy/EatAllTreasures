using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeElement : MonoBehaviour
{
    [SerializeField] protected Player Player;
    [SerializeField] protected float Cost;
    [SerializeField] protected float Enhancement;
    [SerializeField] protected float CostIncrease;
    [SerializeField] protected float EnhancementIncrease;
    [SerializeField] protected TMP_Text Text;
    [SerializeField] protected Button Button;

    protected void ChangeCost()
    {
        Cost += CostIncrease;
        Enhancement += EnhancementIncrease;
        ChangeText();
    }

    private void Awake()
    {
        ChangeText();
    }

    private void Update()
    {
        if (Player.Money < Cost)
            Button.interactable = false;
        else
            Button.interactable = true;
    }

    private void ChangeText()
    {
        Text.text = Cost.ToString();
    }
}
