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
