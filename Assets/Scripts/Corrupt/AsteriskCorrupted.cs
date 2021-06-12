using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriskCorrupted : PlayerCharacter
{
    public override void PlayerCollision(Collision2D collision)
    {
        Glitch.SetActive(true);
        Glitch.transform.position = gameObject.transform.position;
        Destroy(gameObject);
        //add uncorrupt animation
    }

    //public override void Fire()
    //{

    //}
}
