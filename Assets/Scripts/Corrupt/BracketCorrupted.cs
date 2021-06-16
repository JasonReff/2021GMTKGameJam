using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BracketCorrupted : CorruptPlayer
{

    public override void Fire()
    {
        if (readyToFire)
        {
            Vector2 newDirection = reticle.characterToReticle.normalized;
            ShootProjectileWithForce(projectilePrefab, newDirection);
            readyToFire = false;
            StartCoroutine(FireRecharge());
        }
    }

    public override void ShootProjectileWithForce(GameObject projectilePrefab, Vector2 direction)
    {
        audioSource.clip = shootSound;
        audioSource.Play();
        Vector3 currentPosition = transform.position;
        float bulletForce = projectilePrefab.GetComponent<Projectile>().projectileForce;
        float bulletForceMultiplier = UpgradeSystem.current.bulletForceMultiplier;
        bulletForce = bulletForce * bulletForceMultiplier;
        GameObject newProjectile = Instantiate(projectilePrefab, currentPosition + (Vector3)direction, Quaternion.identity);
        newProjectile.GetComponent<Rigidbody2D>().AddForce(direction * bulletForce);
        float rotation = Vector2.Angle(direction, new Vector2(-1, 0));
        newProjectile.transform.Rotate(0, 0, rotation);
    }
}
