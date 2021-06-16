using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriskCorrupted : CorruptPlayer
{

    public override void Fire()
    {
        if (readyToFire)
        {
            audioSource.clip = shootSound;
            audioSource.Play();
            Vector2 newDirection = -reticle.characterToReticle.normalized;
            GameObject projectile1 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
            GameObject projectile2 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection + new Vector3(newDirection.y, -newDirection.x), Quaternion.identity);
            GameObject projectile3 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection + new Vector3(-newDirection.y, newDirection.x), Quaternion.identity);
            GameObject projectile4 = Instantiate(projectilePrefab, gameObject.transform.position + new Vector3(newDirection.y, -newDirection.x), Quaternion.identity);
            GameObject projectile5 = Instantiate(projectilePrefab, gameObject.transform.position + new Vector3(-newDirection.y, newDirection.x), Quaternion.identity);
            GameObject projectile6 = Instantiate(projectilePrefab, gameObject.transform.position - (Vector3)newDirection + new Vector3(newDirection.y, -newDirection.x), Quaternion.identity);
            GameObject projectile7 = Instantiate(projectilePrefab, gameObject.transform.position - (Vector3)newDirection + new Vector3(-newDirection.y, newDirection.x), Quaternion.identity);
            GameObject projectile8 = Instantiate(projectilePrefab, gameObject.transform.position - (Vector3)newDirection, Quaternion.identity);
            Vector2 projectile2Direction = newDirection + new Vector2(newDirection.y, -newDirection.x);
            Vector2 projectile3Direction = newDirection + new Vector2(-newDirection.y, newDirection.x);
            Vector2 projectile4Direction = new Vector2(newDirection.y, -newDirection.x);
            Vector2 projectile5Direction = new Vector2(-newDirection.y, newDirection.x);
            Vector2 projectile6Direction = -newDirection + new Vector2(newDirection.y, -newDirection.x);
            Vector2 projectile7Direction = -newDirection + new Vector2(-newDirection.y, newDirection.x);
            projectile1.GetComponent<Rigidbody2D>().AddForce(newDirection * projectile1.GetComponent<Projectile>().projectileForce);
            projectile2.GetComponent<Rigidbody2D>().AddForce(projectile2Direction * projectile2.GetComponent<Projectile>().projectileForce);
            projectile3.GetComponent<Rigidbody2D>().AddForce(projectile3Direction * projectile3.GetComponent<Projectile>().projectileForce);
            projectile4.GetComponent<Rigidbody2D>().AddForce(projectile4Direction * projectile4.GetComponent<Projectile>().projectileForce);
            projectile5.GetComponent<Rigidbody2D>().AddForce(projectile5Direction * projectile5.GetComponent<Projectile>().projectileForce);
            projectile6.GetComponent<Rigidbody2D>().AddForce(projectile6Direction * projectile6.GetComponent<Projectile>().projectileForce);
            projectile7.GetComponent<Rigidbody2D>().AddForce(projectile7Direction * projectile7.GetComponent<Projectile>().projectileForce);
            projectile8.GetComponent<Rigidbody2D>().AddForce(-newDirection * projectile1.GetComponent<Projectile>().projectileForce);
            readyToFire = false;
            StartCoroutine(FireRecharge());
        }
    }
}
