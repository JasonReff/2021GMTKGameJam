using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class AsteriskCorrupted : PlayerCharacter
{

    public override void Start()
    {

    }

    public override void PlayerCollision(Collision2D collision)
    {
        Glitch.SetActive(true);
        Glitch.transform.position = gameObject.transform.position;
        Destroy(gameObject);
        //add uncorrupt animation
    }

    public override void Fire()
    {
        Vector2 newDirection = reticle.characterToReticle / 10;
        GameObject projectile1 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        GameObject projectile2 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection + (Vector3)newDirection.Perpendicular1(), Quaternion.identity);
        GameObject projectile3 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection + (Vector3)newDirection.Perpendicular2(), Quaternion.identity);
        GameObject projectile4 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection.Perpendicular1(), Quaternion.identity);
        GameObject projectile5 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection.Perpendicular2(), Quaternion.identity);
        GameObject projectile6 = Instantiate(projectilePrefab, gameObject.transform.position - (Vector3)newDirection + (Vector3)newDirection.Perpendicular1(), Quaternion.identity);
        GameObject projectile7 = Instantiate(projectilePrefab, gameObject.transform.position - (Vector3)newDirection + (Vector3)newDirection.Perpendicular2(), Quaternion.identity);
        GameObject projectile8 = Instantiate(projectilePrefab, gameObject.transform.position - (Vector3)newDirection, Quaternion.identity);
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
}
