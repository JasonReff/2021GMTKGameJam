using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int id;
    public float movementSpeed;
    public float minimumDistanceFromPLayer;
    public float distanceFromPlayer;
    public Vector2 enemyToPlayer;
    public GameObject player;
    public int hp;

    void Update()
    {
        enemyToPlayer = transform.position - player.transform.position;
        distanceFromPlayer = enemyToPlayer.magnitude;
        if (distanceFromPlayer > minimumDistanceFromPLayer)
        {
            EnemyMove();
        }
    }

    public virtual void EnemyMove()
    {
        Vector2 direction = new Vector2 (enemyToPlayer.x / enemyToPlayer.magnitude, enemyToPlayer.y / enemyToPlayer.magnitude);
        transform.position += new Vector3 (direction.x * movementSpeed, direction.y * movementSpeed, 0);
    }

    public virtual void EnemyFire()
    {
        //must make this
    }

    public void TakeDamage()
    {
        hp--;
        if (hp <= 0)
        {
            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {
        Destroy(this);
        //play death animation
    }

    public void Awake()
    {
        EnemyMove();
    }
}
