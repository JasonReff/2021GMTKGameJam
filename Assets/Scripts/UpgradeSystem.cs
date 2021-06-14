using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public static UpgradeSystem current;
    public float bulletForceMultiplier;
    public float movementSpeedMultiplier;
    public float bulletRangeMultiplier;
    public float fireRateMultiplier;
    public float lifespanMultiplier;

    public void BulletForceUp()
    {
        bulletForceMultiplier = (float)(bulletForceMultiplier * 1.1);
    }

    public void MovementSpeedUp()
    {
        movementSpeedMultiplier = (float)(movementSpeedMultiplier * 1.1);
    }

    public void BulletRangeUp()
    {
        bulletRangeMultiplier = (float)(bulletRangeMultiplier * 1.1);
    }

}
