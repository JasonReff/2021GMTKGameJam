using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCorrupt : PlayerCharacter
{

    public override void Start()
    {
        
    }
    public override void PlayerCollision(Collision2D collision)
    {
        GameObject player = GameObject.Find("PlayerCharacter");
        player.SetActive(true);
        Destroy(gameObject);
    }

    public override void Fire()
    {
        audioSource.clip = shootSound;
        audioSource.Play();
        Vector2 newDirection = -reticle.characterToReticle / 10;
        GameObject projectile = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile.GetComponent<Projectile>().projectileForce);
    }
}
