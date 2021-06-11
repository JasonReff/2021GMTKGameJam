using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObject = collision.collider.gameObject;
        switch (collisionObject.GetComponent<Entity>().characterOrEnemy)
        {
            case Entity.CharacterOrEnemy.Character:
                break;
            case Entity.CharacterOrEnemy.Enemy:
                break;
            default:
                break;
        }
    }
}
