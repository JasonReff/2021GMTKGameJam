using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float projectileForce;
    public float rangeInSeconds;
    public float time;

    private void Awake()
    {
        time = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.collider.gameObject.GetComponent<Enemy>() != null)
            {
                collision.collider.gameObject.GetComponent<Enemy>().EnemyDeath();
            }
            else
            {
                collision.collider.gameObject.GetComponent<PlayerCharacter>().PlayerDeath();
            }
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= rangeInSeconds)
        {
            Destroy(gameObject);
        }
    }

}
