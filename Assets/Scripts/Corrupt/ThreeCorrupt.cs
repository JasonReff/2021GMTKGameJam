using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeCorrupt : CorruptPlayer
{

    public override void Fire()
    {
        if (readyToFire)
        {
            audioSource.clip = shootSound;
            audioSource.Play();
            Vector2 newDirection = reticle.characterToReticle.normalized;
            GameObject projectile1 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
            GameObject projectile2 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection + new Vector3(newDirection.y, -newDirection.x), Quaternion.identity);
            GameObject projectile3 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection + new Vector3(-newDirection.y, newDirection.x), Quaternion.identity);
            Vector2 projectile2Direction = newDirection + new Vector2(newDirection.y, -newDirection.x);
            Vector2 projectile3Direction = newDirection + new Vector2(-newDirection.y, newDirection.x);
            projectile1.GetComponent<Rigidbody2D>().AddForce(newDirection * projectile1.GetComponent<Projectile>().projectileForce);
            projectile2.GetComponent<Rigidbody2D>().AddForce(projectile2Direction * projectile2.GetComponent<Projectile>().projectileForce);
            projectile3.GetComponent<Rigidbody2D>().AddForce(projectile3Direction * projectile3.GetComponent<Projectile>().projectileForce);
            readyToFire = false;
            StartCoroutine(FireRecharge());
        }
    }
}
