using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCorrupt : PlayerCharacter
{
    public override void PlayerCollision(Collision2D collision)
    {
        GameObject player = GameObject.Find("PlayerCharacter");
        player.SetActive(true);
        Destroy(gameObject);
    }

    //public override void Fire()
    //{

    //}
}
