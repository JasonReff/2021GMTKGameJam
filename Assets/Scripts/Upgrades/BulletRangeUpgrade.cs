using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRangeUpgrade : Upgrade
{
    public BulletRangeUpgrade()
    {
        cost = 5;
        upgradeName = "Bullet Range";
        upgradeDescription = "Increase bullet range by 10%.";
    }
    public override void UpgradeEffect()
    {
        UpgradeSystem.current.bulletRangeMultiplier = (float)(UpgradeSystem.current.bulletRangeMultiplier * 1.1);
    }
}
