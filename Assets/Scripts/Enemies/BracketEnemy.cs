using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BracketEnemy : Enemy
{

    public override void EnemyFire()
    {
        Vector2 newDirection = -enemyToPlayer / 10;
        float rotation = Vector2.Angle(newDirection, new Vector2(-1, 0));
        GameObject projectile = Instantiate(enemyProjectile, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        projectile.transform.Rotate(0, 0, rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile.GetComponent<Projectile>().projectileForce);
    }
}
