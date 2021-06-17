using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMarkCorrupt : CorruptPlayer
{

    public GameObject OProjectile;
    public AudioClip OFireSound;
    public GameObject ThreeProjectile;
    public AudioClip ThreeFireSound;
    public GameObject AmpersandProjectile;
    public AudioClip AmpersandFireSound;
    public GameObject AsteriskProjectile;
    public AudioClip AsteriskFireSound;
    public AudioClip BracketFireSound;
    public GameObject BracketProjectile;

    public override void Fire()
    {
        if (readyToFire)
        {
            int firingPattern = UnityEngine.Random.Range(1, 6);
            switch (firingPattern)
            {
                case 1: OFire(); break;
                case 2: ThreeFire(); break;
                case 3: BracketFire(); break;
                case 4: AmpersandFire(); break;
                case 5: AsteriskFire(); break;
            }
        }
    }

    void OFire()
    {
        audioSource.clip = OFireSound;
        audioSource.Play();
        Vector2 newDirection = reticle.characterToReticle.normalized;
        ShootProjectileWithForce(OProjectile, newDirection);
        readyToFire = false;
        StartCoroutine(FireRecharge());
    }

    void ThreeFire()
    {
        audioSource.clip = ThreeFireSound;
        audioSource.Play();
        Vector2 direction1 = reticle.characterToReticle.normalized;
        Vector2 direction2 = direction1 + new Vector2(direction1.y, -direction1.x);
        Vector2 direction3 = direction1 + new Vector2(-direction1.y, direction1.x);
        ShootProjectileWithForce(ThreeProjectile, direction1);
        ShootProjectileWithForce(ThreeProjectile, direction2);
        ShootProjectileWithForce(ThreeProjectile, direction3);
        readyToFire = false;
        StartCoroutine(FireRecharge());
    }

    void BracketFire()
    {
        audioSource.clip = BracketFireSound;
        audioSource.Play();
        Vector2 direction = reticle.characterToReticle.normalized;
        Vector3 currentPosition = transform.position;
        float bulletForce = BracketProjectile.GetComponent<Projectile>().projectileForce;
        float bulletForceMultiplier = UpgradeSystem.current.bulletForceMultiplier;
        bulletForce = bulletForce * bulletForceMultiplier;
        GameObject newProjectile = Instantiate(BracketProjectile, currentPosition + (Vector3)direction, Quaternion.identity);
        newProjectile.GetComponent<Rigidbody2D>().AddForce(direction * bulletForce);
        float rotation = Vector2.Angle(direction, new Vector2(-1, 0));
        newProjectile.transform.Rotate(0, 0, rotation);
        readyToFire = false;
        StartCoroutine(FireRecharge());
    }

    void AmpersandFire()
    {
        StartCoroutine(FireProjectiles());
        readyToFire = false;
        StartCoroutine(FireRecharge());
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
        audioSource.clip = AmpersandFireSound;
        audioSource.Play(); 
        Vector2 newDirection = reticle.characterToReticle.normalized;
        ShootProjectileWithForce(AmpersandProjectile, newDirection);
    }

    void AsteriskFire()
    {
        audioSource.clip = AsteriskFireSound;
        audioSource.Play();
        List<Vector2> directions = new List<Vector2> { };
        Vector2 direction1 = reticle.characterToReticle.normalized;
        directions.Add(direction1);
        Vector2 direction2 = direction1 + new Vector2(direction1.y, -direction1.x);
        directions.Add(direction2);
        Vector2 direction3 = direction1 + new Vector2(-direction1.y, direction1.x);
        directions.Add(direction3);
        Vector2 direction4 = new Vector2(direction1.y, -direction1.x);
        directions.Add(direction4);
        Vector2 direction5 = new Vector2(-direction1.y, direction1.x);
        directions.Add(direction5);
        Vector2 direction6 = -direction1 + new Vector2(direction1.y, -direction1.x);
        directions.Add(direction6);
        Vector2 direction7 = -direction1 + new Vector2(-direction1.y, direction1.x);
        directions.Add(direction7);
        Vector2 direction8 = -direction1;
        directions.Add(direction8);
        for (int i = 0; i <= 7; i++)
        {
            ShootProjectileWithForce(AsteriskProjectile, directions[i]);
        }
        readyToFire = false;
        StartCoroutine(FireRecharge());
    }
}
