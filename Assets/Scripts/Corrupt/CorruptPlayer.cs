using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptPlayer : PlayerCharacter
{

    public override void Start()
    {
        anim.SetBool("Corrupt", true);
        Invoke("StopAnimation", .8f);
        StartCoroutine(LifespanTick());
    }

    public void StopAnimation()
    {
        anim.SetBool("Corrupt", false);
    }

    public override void PlayerCollision(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<DataPickup>() != null)
        {
            return;
        }
        if (collision.collider.gameObject.GetComponent<Enemy>() != null)
        {
            collision.collider.gameObject.GetComponent<Enemy>().EnemyDies();
        }
        Uncorrupt();
    }

    public override void Uncorrupt()
    {
        Glitch.SetActive(true);
        Glitch.transform.position = gameObject.transform.position;
        EventSystem.current.activePlayer = Glitch.GetComponent<PlayerCharacter>();
        Destroy(gameObject);
        Glitch.GetComponent<PlayerCharacter>().Uncorrupt();
        //add uncorrupt animation
    }

}
