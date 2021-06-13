using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BracketCorrupted : PlayerCharacter
{

    public override void Start()
    {
        
    }
    public override void PlayerCollision(Collision2D collision)
    {
        Glitch.SetActive(true);
        Glitch.transform.position = gameObject.transform.position;
        GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().activePlayer = Glitch.GetComponent<PlayerCharacter>();
        Destroy(gameObject);
        //add uncorrupt animation
    }

    public override void Fire()
    {
        if (readyToFire)
        {
            audioSource.clip = shootSound;
            audioSource.Play();
            Vector2 newDirection = reticle.characterToReticle / 10;
            GameObject projectile = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile.GetComponent<Projectile>().projectileForce);
            readyToFire = false;
            StartCoroutine(FireRecharge());
        }
    }
}
