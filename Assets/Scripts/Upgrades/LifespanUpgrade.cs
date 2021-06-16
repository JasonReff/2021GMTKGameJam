using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifespanUpgrade : Upgrade
{

    public LifespanUpgrade()
    {
        cost = 4;
        upgradeName = "Lifespan Length";
        upgradeDescription = "Increase corruption duration by 10%.";
    }
    public override void UpgradeEffect()
    {
        UpgradeSystem.current.lifespanMultiplier = (float)(UpgradeSystem.current.lifespanMultiplier * 1.1);
    }
}
