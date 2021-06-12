using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BracketEnemy : Enemy
{
    public GameObject shield;
    public float boostForce;
    public bool isShieldOn;

    public override void EnemyFire()
    {
        StartCoroutine(ShieldAndBoost());
    }

    public IEnumerator ShieldAndBoost()
    {
        TurnShieldOn();
        Boost();
        yield return new WaitForSeconds(1f);
        Decelerate();
        yield return new WaitForSeconds(1f);
        TurnShieldOff();
    }

    void TurnShieldOn()
    {
        isShieldOn = true;
        shield.SetActive(true);
    }

    void Decelerate()
    {
        Vector2 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        Vector2 decelerationForce = -velocity * boostForce * 0.5f;
        gameObject.GetComponent<Rigidbody2D>().AddForce(decelerationForce);
    }

    void TurnShieldOff()
    {
        isShieldOn = false;
        shield.SetActive(false);
    }

    void Boost()
    {
        Vector2 boostDirection = -enemyToPlayer;
        gameObject.GetComponent<Rigidbody2D>().AddForce(boostDirection * boostForce);

    }
}
