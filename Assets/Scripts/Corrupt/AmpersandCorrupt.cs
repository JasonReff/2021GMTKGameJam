using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpersandCorrupt : PlayerCharacter
{

    public override void Start()
    {
        
    }
    public override void PlayerCollision(Collision2D collision)
    {
        GameObject player = GameObject.Find("PlayerCharacter");
        player.SetActive(true);
        Destroy(gameObject);
        //add death animation
    }

    public override void Fire()
    {
        audioSource.clip = shootSound;
        audioSource.Play();
        StartCoroutine(FireProjectiles());
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
        Vector2 newDirection = -reticle.characterToReticle;
        GameObject projectile = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(newDirection * projectile.GetComponent<Projectile>().projectileForce);
    }
}
