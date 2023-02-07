using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _moneyMultiplier;
    [SerializeField] private int _money;
    [SerializeField] private GameObject _textPopupPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private ParticleSystem _particleSystemWinning;
    [SerializeField] private GameObject _endPanel;

    public float Speed => _speed;
    public float MaxDistance => _maxDistance;
    public float PointsMultiplier => _moneyMultiplier;
    public int Money => _money;

    public int StartMoney => _startMoney;

    public int EndMoney => _endMoney;  

    public event UnityAction<int> MoneyChanged;
    public event UnityAction<float> DistanceChanged;

    private readonly string _eatingAnimation = "Taunting";
    private readonly string _isWinning = "isWinning";
    private Animator _animator;
    private AudioSource _audioSource;
    private int _startMoney;
    private int _endMoney;

    public void AddMoney(float reward)
    {
        int rewardMultiplier = Convert.ToInt32(reward * _moneyMultiplier);
        _money += rewardMultiplier;
        _endMoney += rewardMultiplier;

        if (_textPopupPrefab)
        {
            ShowTextPopup(rewardMultiplier);
        }

        MoneyChanged?.Invoke(_money);
        _audioSource.Play();
        _animator.Play(_eatingAnimation);
    }

    public void UpgradeDistance(float cost, float enhancement)
    {
        _money -= Convert.ToInt32(cost);
        MoneyChanged?.Invoke(_money);
        DistanceChanged?.Invoke(_maxDistance);
        _maxDistance += enhancement;
    }
    public void UpgradeSpeed(float cost, float enhancement)
    {
        _money -= Convert.ToInt32(cost);
        MoneyChanged?.Invoke(_money);
        _speed += enhancement;
    }
    public void UpgradeMultiplier(float cost, float enhancement)
    {
        _money -= Convert.ToInt32(cost);
        MoneyChanged?.Invoke(_money);
        _moneyMultiplier += enhancement;
    }

    public void Win()
    {
        _animator.SetBool(_isWinning, true);
        Instantiate(_particleSystemWinning, transform.position, Quaternion.identity);
        _endPanel.SetActive(true);
    }

    private void ShowTextPopup(int reward)
    {
        int index = Random.Range(0,_spawnPoints.Length);
        var text = Instantiate(_textPopupPrefab, _spawnPoints[index].position, Quaternion.identity, _spawnPoints[index].gameObject.transform);
        text.GetComponent<TextMeshPro>().text = reward.ToString();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        MoneyChanged?.Invoke(_money);
        DistanceChanged.Invoke(_maxDistance);
        _startMoney = _money;
    }
}
