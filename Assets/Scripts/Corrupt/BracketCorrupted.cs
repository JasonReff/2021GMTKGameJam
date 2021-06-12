using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BracketCorrupted : PlayerCharacter
{
    public override void PlayerCollision(Collision2D collision)
    {
        GameObject player = GameObject.Find("PlayerCharacter");
        player.SetActive(true);
        Destroy(gameObject);
        //add death animation
    }

    //public override void Fire()
    //{

    //}
}
