using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeEnemy : Enemy
{

    public override void EnemyFire()
    {
        Vector2 projectileOffset = enemyToPlayer.Perpendicular1();
        GameObject projectile1 = Instantiate(enemyProjectile, gameObject.transform.position + projectileOffset);
        GameObject projectile2 = Instantiate(enemyProjectile);
        GameObject projectile3 = Instantiate(enemyProjectile);
        projectile1.GetComponent<Rigidbody2D>().AddForce(enemyToPlayer * projectile.GetComponent<Projectile>().projectileForce);
        projectile2.GetComponent<Rigidbody2D>().AddForce(enemyToPlayer.Perpendicular1() * projectile.GetComponent<Projectile>().projectileForce);
        projectile3.GetComponent<Rigidbody2D>().AddForce(enemyToPlayer.Perpendicular1() * projectile.GetComponent<Projectile>().projectileForce);
    }
}
