using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCorrupt : CorruptPlayer
{

    public override void Fire()
    {
        if (readyToFire)
        {
            audioSource.clip = shootSound();
            audioSource.Play();
            Vector2 newDirection = reticle.characterToReticle.normalized;
            ShootProjectileWithForce(projectilePrefab, newDirection);
            readyToFire = false;
            StartCoroutine(FireRecharge());
        }
    }
}
