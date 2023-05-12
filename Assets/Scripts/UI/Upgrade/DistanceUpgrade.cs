using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Agava.YandexGames.Samples;

public class DistanceUpgrade : UpgradeElement
{
    [SerializeField] private Enemies _enemies;

    private readonly string _distanceCostKey = "DistanceCost";
    private bool _isFirstUpgrade = true;

    private void Awake()
    {
        Cost = PlayerPrefs.GetFloat(_distanceCostKey);

        ChangeText();
    }

    public override void Upgrade()
    {
        Player.UpgradeDistance(Cost, Enhancement);
        base.Upgrade();

        if(_isFirstUpgrade)
        {
            _isFirstUpgrade = false;

            if (_enemies.HaveThirdPhaze == true)
                _enemies.SpawnLastPhaze();
        }

        if (MaxEnhancement == Player.MaxDistance)
        {
            IsMaxEnhancement = true;

            if (_enemies.HaveThirdPhaze == true)
                _enemies.SpawnLastPhaze();
        }
            
    }

    public override void AdUpgrade()
    {
        Player.UpgradeDistance(0, Enhancement);
        base.AdUpgrade();

        if (_isFirstUpgrade)
        {
            _isFirstUpgrade = false;

            if (_enemies.HaveThirdPhaze == true)
                _enemies.SpawnLastPhaze();
        }

        if (MaxEnhancement == Player.MaxDistance)
        {
            IsMaxEnhancement = true;
        }
        else
        {
            IsRewardedVideoShowed = false;
        }
    }
}
