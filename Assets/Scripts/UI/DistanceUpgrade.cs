using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceUpgrade : UpgradeElement
{
    public void Upgrade()
    {
        if (Player.Money < Cost)
            return;

        Player.UpgradeDistance(Cost, Enhancement);
        ChangeCost();
    }
}
