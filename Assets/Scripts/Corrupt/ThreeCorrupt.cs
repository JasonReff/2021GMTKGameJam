using UnityEngine;

public class ThreeCorrupt : CorruptPlayer
{

    public override void Fire()
    {
        if (readyToFire)
        {
            audioSource.clip = shootSound;
            audioSource.Play();
            Vector2 direction1 = reticle.characterToReticle.normalized;
            Vector2 direction2 = direction1 + new Vector2(direction1.y, -direction1.x);
            Vector2 direction3 = direction1 + new Vector2(-direction1.y, direction1.x);
            ShootProjectileWithForce(projectilePrefab, direction1);
            ShootProjectileWithForce(projectilePrefab, direction2);
            ShootProjectileWithForce(projectilePrefab, direction3);
            readyToFire = false;
            StartCoroutine(FireRecharge());
        }
    }
}
