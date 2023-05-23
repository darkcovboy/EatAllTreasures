using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLose : MonoBehaviour
{
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private DistanceUpgrade _distanceUpgrade;
    [SerializeField] private Enemies _enemies;
    [SerializeField] private LoseField _loseField;

    private readonly string _levelKey = "Level";

    private void Update()
    {
        if (_enemies.CurrentEnemies * PlayerPrefs.GetInt(_levelKey) < _distanceUpgrade.GetCost() && _distanceUpgrade.GetMaxEnchancement() == false && _moneyCounter.Money < _distanceUpgrade.GetCost())
        {
            if(_enemies.HaveThirdPhaze == false)
            {
                _loseField.gameObject.SetActive(true);
            }
            else
            {
                if (_enemies.HaveThirdPhazeSpawned == true)
                {
                    _loseField.gameObject.SetActive(true);
                }
            }
        }
    }
}
