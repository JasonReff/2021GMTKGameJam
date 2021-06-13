using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMarkEnemy : Enemy
{
    public GameObject OProjectile;
    public GameObject ThreeProjectile;
    public GameObject AsteriskProjectile;
    public GameObject AmpersandProjectile;
    public GameObject BracketProjectile;
    public override void EnemyFire()
    {
        int shot = UnityEngine.Random.Range(1, 6);
        switch (shot)
        {
            case 1:
                OEnemyFire();
                break;
            case 2:
                ThreeEnemyFire();
                break;
            case 3:
                StartCoroutine(AmpersandEnemyFire());
                break;
            case 4:
                AsteriskEnemyFire();
                break;
            case 5:
                BracketEnemyFire();
                break;
        }
    }

    public void OEnemyFire()
    {
        Vector2 newDirection = -enemyToPlayer / 10;
        GameObject projectile = Instantiate(OProjectile, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile.GetComponent<Projectile>().projectileForce);
    }

    public void ThreeEnemyFire()
    {
        Vector2 newDirection = -enemyToPlayer / 10;
        GameObject projectile1 = Instantiate(ThreeProjectile, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        GameObject projectile2 = Instantiate(ThreeProjectile, gameObject.transform.position + (Vector3)newDirection + new Vector3(newDirection.y, -newDirection.x), Quaternion.identity);
        GameObject projectile3 = Instantiate(ThreeProjectile, gameObject.transform.position + (Vector3)newDirection + new Vector3(-newDirection.y, newDirection.x), Quaternion.identity);
        Vector2 projectile2Direction = newDirection + new Vector2(newDirection.y, -newDirection.x);
        Vector2 projectile3Direction = newDirection + new Vector2(-newDirection.y, newDirection.x);
        projectile1.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile1.GetComponent<Projectile>().projectileForce);
        projectile2.GetComponent<Rigidbody2D>().AddForce(projectile2Direction * 10 * projectile2.GetComponent<Projectile>().projectileForce);
        projectile3.GetComponent<Rigidbody2D>().AddForce(projectile3Direction * 10 * projectile3.GetComponent<Projectile>().projectileForce);
    }

    public void AsteriskEnemyFire()
    {
        Vector2 newDirection = -enemyToPlayer / 10;
        GameObject projectile1 = Instantiate(AsteriskProjectile, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        GameObject projectile2 = Instantiate(AsteriskProjectile, gameObject.transform.position + (Vector3)newDirection + new Vector3(newDirection.y, -newDirection.x), Quaternion.identity);
        GameObject projectile3 = Instantiate(AsteriskProjectile, gameObject.transform.position + (Vector3)newDirection + new Vector3(-newDirection.y, newDirection.x), Quaternion.identity);
        GameObject projectile4 = Instantiate(AsteriskProjectile, gameObject.transform.position + new Vector3(newDirection.y, -newDirection.x), Quaternion.identity);
        GameObject projectile5 = Instantiate(AsteriskProjectile, gameObject.transform.position + new Vector3(-newDirection.y, newDirection.x), Quaternion.identity);
        GameObject projectile6 = Instantiate(AsteriskProjectile, gameObject.transform.position - new Vector3(newDirection.y, -newDirection.x), Quaternion.identity);
        GameObject projectile7 = Instantiate(AsteriskProjectile, gameObject.transform.position - (Vector3)newDirection + new Vector3(-newDirection.y, newDirection.x), Quaternion.identity);
        GameObject projectile8 = Instantiate(AsteriskProjectile, gameObject.transform.position - (Vector3)newDirection, Quaternion.identity);
        Vector2 projectile2Direction = newDirection + new Vector2(newDirection.y, -newDirection.x);
        Vector2 projectile3Direction = newDirection + new Vector2(-newDirection.y, newDirection.x);
        Vector2 projectile4Direction = new Vector3(newDirection.y, -newDirection.x);
        Vector2 projectile5Direction = new Vector3(-newDirection.y, newDirection.x);
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

    IEnumerator AmpersandEnemyFire()
    {
        for (int i = 0; i <= 2; i++)
        {
            yield return new WaitForSeconds(.2f);
            Fire1Projectile();
        }
    }

    void Fire1Projectile()
    {
        Vector2 newDirection = -enemyToPlayer /10;
        GameObject projectile = Instantiate(AmpersandProjectile, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile.GetComponent<Projectile>().projectileForce);
    }

    void BracketEnemyFire()
    {
        Vector2 newDirection = -enemyToPlayer / 10;
        GameObject projectile = Instantiate(BracketProjectile, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile.GetComponent<Projectile>().projectileForce);
    }
}
