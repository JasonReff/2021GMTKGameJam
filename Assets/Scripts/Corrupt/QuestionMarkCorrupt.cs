using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMarkCorrupt : PlayerCharacter
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
    public GameObject Shield;
    public bool isShieldOn;

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
        Vector2 newDirection = reticle.characterToReticle / 10;
        GameObject projectile = Instantiate(OProjectile, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile.GetComponent<Projectile>().projectileForce);
        readyToFire = false;
        StartCoroutine(FireRecharge());
    }

    void ThreeFire()
    {
        audioSource.clip = ThreeFireSound;
        audioSource.Play();
        Vector2 newDirection = reticle.characterToReticle / 10;
        GameObject projectile1 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        GameObject projectile2 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection + new Vector3(newDirection.y, -newDirection.x), Quaternion.identity);
        GameObject projectile3 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection + new Vector3(-newDirection.y, newDirection.x), Quaternion.identity);
        Vector2 projectile2Direction = newDirection + new Vector2(newDirection.y, -newDirection.x);
        Vector2 projectile3Direction = newDirection + new Vector2(-newDirection.y, newDirection.x);
        projectile1.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile1.GetComponent<Projectile>().projectileForce);
        projectile2.GetComponent<Rigidbody2D>().AddForce(projectile2Direction * 10 * projectile2.GetComponent<Projectile>().projectileForce);
        projectile3.GetComponent<Rigidbody2D>().AddForce(projectile3Direction * 10 * projectile3.GetComponent<Projectile>().projectileForce);
        readyToFire = false;
        FireRecharge();
    }

    void BracketFire()
    {

    }

    void AmpersandFire()
    {
        audioSource.clip = AmpersandFireSound;
        audioSource.Play();
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
        Vector2 newDirection = reticle.characterToReticle;
        GameObject projectile = Instantiate(AmpersandProjectile, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(newDirection * projectile.GetComponent<Projectile>().projectileForce);
    }

    void AsteriskFire()
    {
        audioSource.clip = AsteriskFireSound;
        audioSource.Play();
        Vector2 newDirection = -reticle.characterToReticle / 10;
        GameObject projectile1 = Instantiate(AsteriskProjectile, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        GameObject projectile2 = Instantiate(AsteriskProjectile, gameObject.transform.position + (Vector3)newDirection + new Vector3(newDirection.y, -newDirection.x), Quaternion.identity);
        GameObject projectile3 = Instantiate(AsteriskProjectile, gameObject.transform.position + (Vector3)newDirection + new Vector3(-newDirection.y, newDirection.x), Quaternion.identity);
        GameObject projectile4 = Instantiate(AsteriskProjectile, gameObject.transform.position + new Vector3(newDirection.y, -newDirection.x), Quaternion.identity);
        GameObject projectile5 = Instantiate(AsteriskProjectile, gameObject.transform.position + new Vector3(-newDirection.y, newDirection.x), Quaternion.identity);
        GameObject projectile6 = Instantiate(AsteriskProjectile, gameObject.transform.position - (Vector3)newDirection + new Vector3(newDirection.y, -newDirection.x), Quaternion.identity);
        GameObject projectile7 = Instantiate(AsteriskProjectile, gameObject.transform.position - (Vector3)newDirection + new Vector3(-newDirection.y, newDirection.x), Quaternion.identity);
        GameObject projectile8 = Instantiate(AsteriskProjectile, gameObject.transform.position - (Vector3)newDirection, Quaternion.identity);
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
        readyToFire = false;
        StartCoroutine(FireRecharge());
    }
}
