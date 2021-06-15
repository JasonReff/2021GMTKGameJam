using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpeedUpgrade : Upgrade
{
    public MovementSpeedUpgrade()
    {
        cost = 4;
        upgradeName = "Movement Speed";
        upgradeDescription = "Increase movement speed by 10%.";
    }
    public override void UpgradeEffect()
    {
        UpgradeSystem.current.movementSpeedMultiplier = (float)(UpgradeSystem.current.movementSpeedMultiplier * 1.1);
    }
}
