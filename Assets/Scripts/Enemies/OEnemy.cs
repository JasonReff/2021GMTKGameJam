using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OEnemy : Enemy
{

    public override void EnemyFire()
    {
        Vector2 newDirection = -enemyToPlayer / 10;
        GameObject projectile = Instantiate(enemyProjectile, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile.GetComponent<Projectile>().projectileForce);
    }
}
