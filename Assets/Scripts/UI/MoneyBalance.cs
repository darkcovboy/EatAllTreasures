using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private MoneyCounter _moneyCounter;

    private void OnEnable()
    {
        _moneyCounter.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _moneyCounter.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _money.text = money.ToString();
    }
}
