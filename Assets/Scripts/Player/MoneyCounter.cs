using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private int _money;

    public event UnityAction<int> MoneyChanged;

    public int Money => _money;

    public int StartMoney => _startMoney;

    public int EndMoney => _endMoney;

    private int _startMoney;
    private int _endMoney;


    private readonly string _moneyKey = "Money";

    private void Start()
    {
        _money = PlayerPrefs.GetInt(_moneyKey);
        MoneyChanged?.Invoke(_money);
        _startMoney = _money;
    }

    public void SpendMoney(int reward)
    {
        _money -= reward;
        MoneyChanged?.Invoke(_money);
    }

    public void AddMoney(int reward)
    {
        _money += reward;
        _endMoney += reward;
        MoneyChanged?.Invoke(_money);
    }
}
