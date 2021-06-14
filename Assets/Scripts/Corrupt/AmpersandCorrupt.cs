using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpersandCorrupt : PlayerCharacter
{ 
    public override void Start()
    {
        anim.SetBool("Corrupt", true);
        Invoke("StopAnimation", .8f);
        StartCoroutine(LifespanTick());
    }

    public void StopAnimation()
    {
        anim.SetBool("Corrupt", false);
    }

    public override void PlayerCollision(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<Enemy>() != null)
        {
            collision.collider.gameObject.GetComponent<Enemy>().EnemyDies();
        }
        Uncorrupt();
    }

    public override void Uncorrupt()
    {
        Glitch.SetActive(true);
        Glitch.transform.position = gameObject.transform.position;
        EventSystem.current.activePlayer = Glitch.GetComponent<PlayerCharacter>();
        Destroy(gameObject);
        Glitch.GetComponent<PlayerCharacter>().Uncorrupt();
        //add uncorrupt animation
    }

    public override void Fire()
    {
        if (readyToFire)
        {
            StartCoroutine(FireProjectiles());
            readyToFire = false;
            StartCoroutine(FireRecharge());
        }
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
        audioSource.clip = shootSound;
        audioSource.Play();
        Vector2 newDirection = reticle.characterToReticle.normalized;
        GameObject projectile = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(newDirection * projectile.GetComponent<Projectile>().projectileForce);
    }
}
