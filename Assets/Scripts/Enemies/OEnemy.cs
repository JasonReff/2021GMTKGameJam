using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class OEnemy : Enemy
{

    public override void EnemyFire()
    {
        GameObject projectile = Instantiate(enemyProjectile);
        projectile.GetComponent<Rigidbody2D>().AddForce(enemyToPlayer * projectile.GetComponent<Projectile>().projectileForce);
    }
}
