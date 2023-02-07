using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuliplierUpgrade : UpgradeElement
{
    public void Upgrade()
    {
        if (Player.Money < Cost)
            return;

        Player.UpgradeMultiplier(Cost, Enhancement);
        ChangeCost();
    }
}
