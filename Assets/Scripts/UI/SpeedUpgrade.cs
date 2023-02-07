using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : UpgradeElement
{
    public void Upgrade()
    {
        Player.UpgradeSpeed(Cost, Enhancement);
        ChangeCost();
    }
}
