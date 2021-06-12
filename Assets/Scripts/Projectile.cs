using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float projectileForce;

    private void Awake()
    {
        Physics.IgnoreLayerCollision(8, 9);
        Physics.IgnoreLayerCollision(8, 8);
        Physics.IgnoreLayerCollision(9, 9);
        Physics.IgnoreLayerCollision(6, 8);
        Physics.IgnoreLayerCollision(7, 9);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
