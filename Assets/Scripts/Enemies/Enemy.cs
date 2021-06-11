using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int id;
    public float movementSpeed;

    void Update()
    {
        EnemyMove();
    }

    public void EnemyMove()
    {
        //must make this
    }

    public virtual void EnemyFire()
    {
        //must make this
    }

    public void EnemyDeath()
    {
        Destroy(this);
        //play death animation
    }
}
