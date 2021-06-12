using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class QuestionMarkEnemy : Enemy
{
    public GameObject shield;
    public float boostForce;
    public bool isShieldOn;
    public GameObject OProjectile;
    public GameObject ThreeProjectile;
    public GameObject AsteriskProjectile;
    public GameObject AmpersandProjectile;
    public override void EnemyFire()
    {
        int shot = UnityEngine.Random.Range(1, 6);
        switch (shot)
        {
            case 1:
                Jam1();
                break;
            case 2:
                Jam2();
                break;
            case 3:
                StartCoroutine(FireProjectiles());
                break;
            case 4:
                Jam4();
                break;
            case 5:
                StartCoroutine(ShieldAndBoost());
                break;
        }
    }

    public void Jam1()
    {
        Vector2 newDirection = -enemyToPlayer / 10;
        GameObject projectile = Instantiate(OProjectile, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile.GetComponent<Projectile>().projectileForce);
    }

    public void Jam2()
    {
        Vector2 newDirection = -enemyToPlayer / 10;
        GameObject projectile1 = Instantiate(ThreeProjectile, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        GameObject projectile2 = Instantiate(ThreeProjectile, gameObject.transform.position + (Vector3)newDirection + (Vector3)newDirection.Perpendicular1(), Quaternion.identity);
        GameObject projectile3 = Instantiate(ThreeProjectile, gameObject.transform.position + (Vector3)newDirection + (Vector3)newDirection.Perpendicular2(), Quaternion.identity);
        Vector2 projectile2Direction = newDirection + (Vector2)newDirection.Perpendicular1();
        Vector2 projectile3Direction = newDirection + (Vector2)newDirection.Perpendicular2();
        projectile1.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile1.GetComponent<Projectile>().projectileForce);
        projectile2.GetComponent<Rigidbody2D>().AddForce(projectile2Direction * 10 * projectile2.GetComponent<Projectile>().projectileForce);
        projectile3.GetComponent<Rigidbody2D>().AddForce(projectile3Direction * 10 * projectile3.GetComponent<Projectile>().projectileForce);
    }

    public void Jam4()
    {
        Vector2 newDirection = -enemyToPlayer / 10;
        GameObject projectile1 = Instantiate(AsteriskProjectile, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        GameObject projectile2 = Instantiate(AsteriskProjectile, gameObject.transform.position + (Vector3)newDirection + (Vector3)newDirection.Perpendicular1(), Quaternion.identity);
        GameObject projectile3 = Instantiate(AsteriskProjectile, gameObject.transform.position + (Vector3)newDirection + (Vector3)newDirection.Perpendicular2(), Quaternion.identity);
        GameObject projectile4 = Instantiate(AsteriskProjectile, gameObject.transform.position + (Vector3)newDirection.Perpendicular1(), Quaternion.identity);
        GameObject projectile5 = Instantiate(AsteriskProjectile, gameObject.transform.position + (Vector3)newDirection.Perpendicular2(), Quaternion.identity);
        GameObject projectile6 = Instantiate(AsteriskProjectile, gameObject.transform.position - (Vector3)newDirection + (Vector3)newDirection.Perpendicular1(), Quaternion.identity);
        GameObject projectile7 = Instantiate(AsteriskProjectile, gameObject.transform.position - (Vector3)newDirection + (Vector3)newDirection.Perpendicular2(), Quaternion.identity);
        GameObject projectile8 = Instantiate(AsteriskProjectile, gameObject.transform.position - (Vector3)newDirection, Quaternion.identity);
        Vector2 projectile2Direction = newDirection + (Vector2)newDirection.Perpendicular1();
        Vector2 projectile3Direction = newDirection + (Vector2)newDirection.Perpendicular2();
        Vector2 projectile4Direction = (Vector2)newDirection.Perpendicular1();
        Vector2 projectile5Direction = (Vector2)newDirection.Perpendicular2();
        Vector2 projectile6Direction = -newDirection + (Vector2)newDirection.Perpendicular1();
        Vector2 projectile7Direction = -newDirection + (Vector2)newDirection.Perpendicular2();
        projectile1.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile1.GetComponent<Projectile>().projectileForce);
        projectile2.GetComponent<Rigidbody2D>().AddForce(projectile2Direction * 10 * projectile2.GetComponent<Projectile>().projectileForce);
        projectile3.GetComponent<Rigidbody2D>().AddForce(projectile3Direction * 10 * projectile3.GetComponent<Projectile>().projectileForce);
        projectile4.GetComponent<Rigidbody2D>().AddForce(projectile4Direction * 10 * projectile4.GetComponent<Projectile>().projectileForce);
        projectile5.GetComponent<Rigidbody2D>().AddForce(projectile5Direction * 10 * projectile5.GetComponent<Projectile>().projectileForce);
        projectile6.GetComponent<Rigidbody2D>().AddForce(projectile4Direction * 10 * projectile6.GetComponent<Projectile>().projectileForce);
        projectile7.GetComponent<Rigidbody2D>().AddForce(projectile5Direction * 10 * projectile7.GetComponent<Projectile>().projectileForce);
        projectile8.GetComponent<Rigidbody2D>().AddForce(-newDirection * 10 * projectile1.GetComponent<Projectile>().projectileForce);
    }

    IEnumerator FireProjectiles()
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

    public IEnumerator ShieldAndBoost()
    {
        TurnShieldOn();
        Boost();
        yield return new WaitForSeconds(0.2f);
        Decelerate();
        yield return new WaitForSeconds(0.3f);
        TurnShieldOff();
    }

    void TurnShieldOn()
    {
        isShieldOn = true;
        shield.SetActive(true);
    }

    void Decelerate()
    {
        Vector2 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        Vector2 decelerationForce = -velocity * boostForce * 0.5f;
        gameObject.GetComponent<Rigidbody2D>().AddForce(decelerationForce);
    }

    void TurnShieldOff()
    {
        isShieldOn = false;
        shield.SetActive(false);
    }

    void Boost()
    {
        Vector2 boostDirection = -enemyToPlayer;
        gameObject.GetComponent<Rigidbody2D>().AddForce(boostDirection * boostForce);

    }
}
