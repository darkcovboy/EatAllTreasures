using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsConfig : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private DistanceUpgrade _distanceUpgradeElement;
    [SerializeField] private SpeedUpgrade _speedUpgradeElement;
    [SerializeField] private MuliplierUpgrade _multiplierUpgradeElement;

    [Header("Start config")]
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _startMultiplier;
    [SerializeField] private float _startDistanceCost;
    [SerializeField] private float _startSpeedCost;
    [SerializeField] private float _startMultiplierCost;

    private readonly int _firstLevel = 1;

    private readonly string _moneyKey = "Money";
    private readonly string _speedKey = "Speed";
    private readonly string _multiplierKey = "Multiplier";
    private readonly string _levelNumber = "Level";
    private readonly string _distanceCostKey = "DistanceCost";
    private readonly string _speedCostKey = "SpeedCost";
    private readonly string _multiplierCostKey = "MultiplierCost";
    private readonly string _lastLevel = "LastLevel";

    private void Start()
    {
        if (!PlayerPrefs.HasKey(_speedKey))
            PlayerPrefs.SetFloat(_speedKey, _startSpeed);

        if (!PlayerPrefs.HasKey(_multiplierKey))
            PlayerPrefs.SetFloat(_multiplierKey, _startMultiplier);

        if (!PlayerPrefs.HasKey(_distanceCostKey))
            PlayerPrefs.SetFloat(_distanceCostKey, _startDistanceCost);

        if (!PlayerPrefs.HasKey(_speedCostKey))
            PlayerPrefs.SetFloat(_speedCostKey, _startSpeedCost);

        if (!PlayerPrefs.HasKey(_multiplierCostKey))
            PlayerPrefs.SetFloat(_multiplierCostKey, _startMultiplierCost);

        if (!PlayerPrefs.HasKey(_levelNumber))
        {
            PlayerPrefs.SetInt(_levelNumber, 0);
        }

        if (PlayerPrefs.GetInt(_lastLevel) != SceneManager.GetActiveScene().buildIndex)
        {
            int level = PlayerPrefs.GetInt(_levelNumber);
            level++;
            PlayerPrefs.SetInt(_levelNumber, level);
        }

        if (!PlayerPrefs.HasKey(_lastLevel))
        {
            PlayerPrefs.SetInt(_lastLevel, _firstLevel);
        }
        else
        {
            PlayerPrefs.SetInt(_lastLevel, SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SetPrefs()
    {
        PlayerPrefs.SetInt(_moneyKey, _moneyCounter.Money);
        PlayerPrefs.SetFloat(_speedKey, _player.Speed);
        PlayerPrefs.SetFloat(_multiplierKey, _player.PointsMultiplier);
        PlayerPrefs.SetFloat(_distanceCostKey, _distanceUpgradeElement.GetCost());
        PlayerPrefs.SetFloat(_speedCostKey, _speedUpgradeElement.GetCost());
        PlayerPrefs.SetFloat(_multiplierCostKey, _multiplierUpgradeElement.GetCost());
        PlayerPrefs.Save();
    }
}
