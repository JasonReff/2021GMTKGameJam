using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BracketCorrupted : PlayerCharacter
{

    public override void Start()
    {
        
    }

    public bool isShieldOn;
    public GameObject shield;
    public float boostForce;
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
            StartCoroutine(ShieldAndBoost());
            readyToFire = false;
            StartCoroutine(FireRecharge());
        }
    }

    public IEnumerator ShieldAndBoost()
    {
        TurnShieldOn();
        yield return new WaitForSeconds(0.3f);
        Boost();
        yield return new WaitForSeconds(0.5f);
        Decelerate();
        yield return new WaitForSeconds(0.5f);
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
        Vector2 boostDirection = -reticle.characterToReticle;
        gameObject.GetComponent<Rigidbody2D>().AddForce(boostDirection * boostForce);

    }
}
