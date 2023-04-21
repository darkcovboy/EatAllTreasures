using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using Agava.YandexGames.Samples;

public class MuliplierUpgrade : UpgradeElement
{
    private readonly string _multiplierCostKey = "MultiplierCost";

    public override void Upgrade()
    {        
        Player.UpgradeMultiplier(Cost, Enhancement);
        base.Upgrade();

        if (MaxEnhancement == Player.PointsMultiplier)
            IsMaxEnhancement = true;
    }

    public override void AdUpgrade()
    {
        Player.UpgradeMultiplier(0, Enhancement);
        base.AdUpgrade();

        if (MaxEnhancement == Player.PointsMultiplier)
            IsMaxEnhancement = true;
    }

    private void Awake()
    {
        Cost = PlayerPrefs.GetFloat(_multiplierCostKey);

        ChangeText();
    }
}
