using UnityEngine;
public class BulletForceUpgrade : Upgrade
{

    public BulletForceUpgrade()
    {
        cost = 5;
        upgradeName = "Bullet Velocity";
        upgradeDescription = "Increase bullet speed by 10%.";
    }

    public override void UpgradeEffect()
    {
        UpgradeSystem.current.bulletForceMultiplier = (float)(UpgradeSystem.current.bulletForceMultiplier * 1.1);
    }

}

