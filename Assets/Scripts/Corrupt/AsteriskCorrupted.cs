using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteriskCorrupted : CorruptPlayer
{

    public override void Fire()
    {
        if (readyToFire)
        {
            audioSource.clip = shootSound;
            audioSource.Play();
            List<Vector2> directions = new List<Vector2> { };
            Vector2 direction1 = reticle.characterToReticle.normalized;
            directions.Add(direction1);
            Vector2 direction2 = direction1 + new Vector2(direction1.y, -direction1.x);
            directions.Add(direction2);
            Vector2 direction3 = direction1 + new Vector2(-direction1.y, direction1.x);
            directions.Add(direction3);
            Vector2 direction4 = new Vector2(direction1.y, -direction1.x);
            directions.Add(direction4);
            Vector2 direction5 = new Vector2(-direction1.y, direction1.x);
            directions.Add(direction5);
            Vector2 direction6 = -direction1 + new Vector2(direction1.y, -direction1.x);
            directions.Add(direction6);
            Vector2 direction7 = -direction1 + new Vector2(-direction1.y, direction1.x);
            directions.Add(direction7);
            Vector2 direction8 = -direction1;
            directions.Add(direction8);
            for (int i = 0; i <= 7; i++)
            {
                ShootProjectileWithForce(projectilePrefab, directions[i]);
            }
            readyToFire = false;
            StartCoroutine(FireRecharge());
        }
    }
}
