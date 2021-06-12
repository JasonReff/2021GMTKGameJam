using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class ThreeCorrupt : PlayerCharacter
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
        Vector2 newDirection = -reticle.characterToReticle / 10;
        GameObject projectile1 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection, Quaternion.identity);
        GameObject projectile2 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection + (Vector3)newDirection.Perpendicular1(), Quaternion.identity);
        GameObject projectile3 = Instantiate(projectilePrefab, gameObject.transform.position + (Vector3)newDirection + (Vector3)newDirection.Perpendicular2(), Quaternion.identity);
        Vector2 projectile2Direction = newDirection + (Vector2)newDirection.Perpendicular1();
        Vector2 projectile3Direction = newDirection + (Vector2)newDirection.Perpendicular2();
        projectile1.GetComponent<Rigidbody2D>().AddForce(newDirection * 10 * projectile1.GetComponent<Projectile>().projectileForce);
        projectile2.GetComponent<Rigidbody2D>().AddForce(projectile2Direction * 10 * projectile2.GetComponent<Projectile>().projectileForce);
        projectile3.GetComponent<Rigidbody2D>().AddForce(projectile3Direction * 10 * projectile3.GetComponent<Projectile>().projectileForce);
    }
}
