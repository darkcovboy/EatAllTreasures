using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Agava.YandexGames.Samples;

public class DistanceUpgrade : UpgradeElement
{
    private readonly string _distanceCostKey = "DistanceCost";

    private void Awake()
    {
        Cost = PlayerPrefs.GetFloat(_distanceCostKey);

        ChangeText();
    }

    public override void Upgrade()
    {
        Player.UpgradeDistance(Cost, Enhancement);
        base.Upgrade();

        if (MaxEnhancement == Player.MaxDistance)
            IsMaxEnhancement = true;
    }

    public override void AdUpgrade()
    {
        Player.UpgradeDistance(0, Enhancement);
        base.AdUpgrade();

        if (MaxEnhancement == Player.MaxDistance)
            IsMaxEnhancement = true;
        else
            IsRewardedVideoShowed = false;
    }
}
