using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReticle : MonoBehaviour
{
    public PlayerCharacter character;
    public Vector2 characterToReticle;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 8);
        if (GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().activePlayer != null)
        {
            PlayerCharacter activePlayer = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().activePlayer;
            characterToReticle = rb.transform.position - activePlayer.rb.transform.position;
        }
        characterToReticle.Normalize();
    }

}
