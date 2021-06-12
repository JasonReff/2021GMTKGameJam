using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpersandEnemy : Enemy
{

    public override void EnemyFire()
    {
        StartCoroutine(FireProjectiles());
    }

    IEnumerator FireProjectiles()
    {
        for (int i =0; i <= 2; i++)
        {
            yield return new WaitForSeconds(.2f);
            Fire1Projectile();
        }
    }

    void Fire1Projectile()
    {
        Vector2 newDirection = -enemyToPlayer / 10;
        GameObject projectile = Instantiate(enemyProjectile, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile.GetComponent<Projectile>().projectileForce);
    }
}
