using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriskEnemy : Enemy
{

    public override void EnemyFire()
    {
        Vector2 newDirection = -enemyToPlayer / 10;
        GameObject projectile1 = Instantiate(enemyProjectile, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        GameObject projectile2 = Instantiate(enemyProjectile, gameObject.transform.position + (Vector3)newDirection + new Vector3(newDirection.y, -newDirection.x), Quaternion.identity);
        GameObject projectile3 = Instantiate(enemyProjectile, gameObject.transform.position + (Vector3)newDirection + new Vector3(-newDirection.y, newDirection.x), Quaternion.identity);
        GameObject projectile4 = Instantiate(enemyProjectile, gameObject.transform.position + new Vector3(newDirection.y, -newDirection.x), Quaternion.identity);
        GameObject projectile5 = Instantiate(enemyProjectile, gameObject.transform.position + new Vector3(-newDirection.y, newDirection.x), Quaternion.identity);
        GameObject projectile6 = Instantiate(enemyProjectile, gameObject.transform.position - (Vector3)newDirection + new Vector3(newDirection.y, -newDirection.x), Quaternion.identity);
        GameObject projectile7 = Instantiate(enemyProjectile, gameObject.transform.position - (Vector3)newDirection + new Vector3(-newDirection.y, newDirection.x), Quaternion.identity);
        GameObject projectile8 = Instantiate(enemyProjectile, gameObject.transform.position - (Vector3)newDirection, Quaternion.identity);
        Vector2 projectile2Direction = newDirection + new Vector2(newDirection.y, -newDirection.x);
        Vector2 projectile3Direction = newDirection + new Vector2(-newDirection.y, newDirection.x);
        Vector2 projectile4Direction = new Vector2(newDirection.y, -newDirection.x);
        Vector2 projectile5Direction = new Vector2(-newDirection.y, newDirection.x);
        Vector2 projectile6Direction = -newDirection + new Vector2(newDirection.y, -newDirection.x);
        Vector2 projectile7Direction = -newDirection + new Vector2(-newDirection.y, newDirection.x);
        projectile1.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile1.GetComponent<Projectile>().projectileForce);
        projectile2.GetComponent<Rigidbody2D>().AddForce(projectile2Direction * 10 * projectile2.GetComponent<Projectile>().projectileForce);
        projectile3.GetComponent<Rigidbody2D>().AddForce(projectile3Direction * 10 * projectile3.GetComponent<Projectile>().projectileForce);
        projectile4.GetComponent<Rigidbody2D>().AddForce(projectile4Direction * 10 * projectile4.GetComponent<Projectile>().projectileForce);
        projectile5.GetComponent<Rigidbody2D>().AddForce(projectile5Direction * 10 * projectile5.GetComponent<Projectile>().projectileForce);
        projectile6.GetComponent<Rigidbody2D>().AddForce(projectile6Direction * 10 * projectile6.GetComponent<Projectile>().projectileForce);
        projectile7.GetComponent<Rigidbody2D>().AddForce(projectile7Direction * 10 * projectile7.GetComponent<Projectile>().projectileForce);
        projectile8.GetComponent<Rigidbody2D>().AddForce(-newDirection * 10 * projectile1.GetComponent<Projectile>().projectileForce);
    }
}
