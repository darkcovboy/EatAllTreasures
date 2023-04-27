using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _maxDistance = 15f;
    [SerializeField] private float _moneyMultiplier = 1f;
    [SerializeField] private GameObject _distanceBlock;
    [SerializeField] private ParticleSystem _particleSystemWinning;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private PlayerPrefsConfig _prefsConfig;
    [SerializeField] private MouthEating _mouth;
    [SerializeField] private CameraMovement _camera;
    [SerializeField] private SpawnerNumbers _spawnerNumbers;
    [SerializeField] private float _distanceStartPos;
    [SerializeField] private MoneyCounter _moneyCounter;

    public float Speed => _speed;
    public float MaxDistance => _maxDistance;
    public float PointsMultiplier => _moneyMultiplier;

    private readonly string _eatingAnimation = "Taunting";
    private readonly string _isWinningAnimation = "IsWinning";
    private readonly string _speedKey = "Speed";
    private readonly string _distanceKey = "Distance";
    private readonly string _multiplierKey = "Multiplier";
    private readonly int _distanceStartX = 0;
    private readonly int _distanceStartY = 0;
    private readonly int _particlePosition = 3;

    private Animator _animator;
    private AudioSource _audioSource;

    private void Start()
    {
        SetConfig();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _maxDistance = _distanceStartPos;
        OnDistanceChange(_maxDistance);
    }

    public void AddMoney(float reward)
    {
        int rewardMultiplier = Convert.ToInt32(reward * _moneyMultiplier);
        _moneyCounter.AddMoney(rewardMultiplier);
        _spawnerNumbers.ShowTextPopup(rewardMultiplier);
        _audioSource.Play();
        _animator.Play(_eatingAnimation);
    }

    public void UpgradeDistance(float cost, float enhancement)
    {
        _moneyCounter.SpendMoney(Convert.ToInt32(cost));
        _maxDistance += enhancement;
        OnDistanceChange(_maxDistance);
    }

    public void UpgradeSpeed(float cost, float enhancement)
    {
        _moneyCounter.SpendMoney(Convert.ToInt32(cost));
        _speed += enhancement;
    }

    public void UpgradeMultiplier(float cost, float enhancement)
    {
        _moneyCounter.SpendMoney(Convert.ToInt32(cost));
        _moneyMultiplier += enhancement;
    }

    public void Win()
    {
        _mouth.gameObject.SetActive(false);
        _prefsConfig.SetPrefs();
        _camera.WinCameraTransform();
        _animator.SetBool(_isWinningAnimation, true);
        Vector3 position = transform.position;
        position.y += _particlePosition;
        Instantiate(_particleSystemWinning, position, Quaternion.identity);
        _endPanel.SetActive(true);
    }

    private void OnDistanceChange(float distance)
    {
        _distanceBlock.transform.position = Vector3.zero;
        _distanceBlock.transform.localPosition = new Vector3(_distanceStartX, _distanceStartY, distance);
    }

    private void SetConfig()
    {
        _maxDistance = PlayerPrefs.GetFloat(_distanceKey);
        _speed = PlayerPrefs.GetFloat(_speedKey);
        _moneyMultiplier = PlayerPrefs.GetFloat(_multiplierKey);
    }
}
