using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _maxDistance = 15f;
    [SerializeField] private float _moneyMultiplier = 1f;
    [SerializeField] private int _money = 0;
    [SerializeField] private GameObject _distanceBlock;
    [SerializeField] private ParticleSystem _particleSystemWinning;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private PlayerPrefsConfig _prefsConfig;
    [SerializeField] private MouthEating _mouth;
    [SerializeField] private CameraMovement _camera;
    [SerializeField] private SpawnerNumbers _spawnerNumbers;
    [SerializeField] private float _distanceStartPos;

    public float Speed => _speed;
    public float MaxDistance => _maxDistance;
    public float PointsMultiplier => _moneyMultiplier;
    public int Money => _money;

    public int StartMoney => _startMoney;

    public int EndMoney => _endMoney;  

    public event UnityAction<int> MoneyChanged;

    private readonly string _eatingAnimation = "Taunting";
    private readonly string _isWinningAnimation = "IsWinning";
    private readonly string _moneyKey = "Money";
    private readonly string _speedKey = "Speed";
    private readonly string _distanceKey = "Distance";
    private readonly string _multiplierKey = "Multiplier";
    private Animator _animator;
    private AudioSource _audioSource;
    private int _startMoney;
    private int _endMoney;

    public void AddMoney(float reward)
    {
        int rewardMultiplier = Convert.ToInt32(reward * _moneyMultiplier);
        _money += rewardMultiplier;
        _endMoney += rewardMultiplier;
        _spawnerNumbers.ShowTextPopup(rewardMultiplier);
        MoneyChanged?.Invoke(_money);
        _audioSource.Play();
        _animator.Play(_eatingAnimation);
    }

    public void UpgradeDistance(float cost, float enhancement)
    {
        _money -= Convert.ToInt32(cost);
        MoneyChanged?.Invoke(_money);
        _maxDistance += enhancement;
        OnDistanceChange(_maxDistance);
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
        _mouth.gameObject.SetActive(false);
        _prefsConfig.SetPrefs();
        _camera.WinCameraTransform();
        _animator.SetBool(_isWinningAnimation, true);
        Vector3 position = transform.position;
        position.y += 3;
        Instantiate(_particleSystemWinning, position, Quaternion.identity);
        _endPanel.SetActive(true);
    }

    private void OnDistanceChange(float distance)
    {
        _distanceBlock.transform.position = Vector3.zero;
        _distanceBlock.transform.localPosition = new Vector3(0, 0, distance);
    }

    private void SetConfig()
    {
        _money = PlayerPrefs.GetInt(_moneyKey);
        _maxDistance = PlayerPrefs.GetFloat(_distanceKey);
        _speed = PlayerPrefs.GetFloat(_speedKey);
        _moneyMultiplier = PlayerPrefs.GetFloat(_multiplierKey);
    }

    private void Start()
    {
        SetConfig();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        MoneyChanged?.Invoke(_money);
        _maxDistance = _distanceStartPos;
        OnDistanceChange(_maxDistance);
        _startMoney = _money;
        StickyAd.Show();
    }
}
