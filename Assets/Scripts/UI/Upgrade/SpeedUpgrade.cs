using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Agava.YandexGames.Samples;

public class SpeedUpgrade : UpgradeElement
{
    private readonly string _speedCostKey = "SpeedCost";

    public override void Upgrade()
    {
        Player.UpgradeSpeed(Cost, Enhancement);
        base.Upgrade();

        if (MaxEnhancement == Player.Speed)
            IsMaxEnhancement = true;
    }

    public override void AdUpgrade()
    {
        Player.UpgradeSpeed(0, Enhancement);
        base.AdUpgrade();

        if (MaxEnhancement == Player.Speed)
            IsMaxEnhancement = true;
    }

    private void Awake()
    {
        Cost = PlayerPrefs.GetFloat(_speedCostKey);

        ChangeText();
    }
}
