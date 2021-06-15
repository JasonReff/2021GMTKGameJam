using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUpgrade : Upgrade
{

    public FireRateUpgrade()
    {
        cost = 6;
        upgradeName = "Fire Rate Upgrade";
        upgradeDescription = "Increase fire rate by 10%.";
    }

    public override void UpgradeEffect()
    {
        UpgradeSystem.current.fireRateMultiplier = (float)(UpgradeSystem.current.fireRateMultiplier * 1.1);
    }
}
