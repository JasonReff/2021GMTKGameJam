using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int id;
    public float movementSpeed;
    public float minimumDistanceFromPlayer;
    public float distanceFromPlayer;
    public float maximumFiringRange;
    public float fireRate;
    public Vector2 enemyToPlayer;
    public GameObject player;
    public int hp;
    public GameObject enemyProjectile;

    public virtual void Awake()
    {
        StartCoroutine(EnemyMove());
        StartCoroutine(FireAtPlayer());
        StartCoroutine(FindPlayer());
    }

    public virtual void Update()
    {
        enemyToPlayer = transform.position - player.transform.position;
        distanceFromPlayer = enemyToPlayer.magnitude;
    }

    public IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(0.3f);
        player = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().activePlayer.gameObject;
        StartCoroutine(FindPlayer());
    }

    public virtual IEnumerator EnemyMove()
    {
        yield return new WaitForSeconds(0.2f);
        if (distanceFromPlayer > minimumDistanceFromPlayer)
        {
            MoveTowardCharacter();
            MoveSideways();
        }
        else
        {
            MoveSideways();
        }
        StartCoroutine(EnemyMove());
    }

    public virtual void MoveSideways()
    {
        Vector2 direction = enemyToPlayer.normalized;
        int leftOrRight = UnityEngine.Random.Range(1, 4);
        Vector2 perpendicular = new Vector2();
        switch (leftOrRight)
        {
            case 1:
                perpendicular = direction.Perpendicular1();
                break;
            case 2:
                perpendicular = direction.Perpendicular2();
                break;
            case 3:
                perpendicular = new Vector2(0, 0);
                break;
        }
        transform.position += new Vector3(perpendicular.x * movementSpeed, perpendicular.y * movementSpeed, 0);
    }

    public virtual void MoveTowardCharacter()
    {
        Vector2 direction = new Vector2(enemyToPlayer.x / enemyToPlayer.magnitude, enemyToPlayer.y / enemyToPlayer.magnitude);
        transform.position -= new Vector3(direction.x * movementSpeed, direction.y * movementSpeed, 0);
    }

    IEnumerator FireAtPlayer()
    {
        if (IsWithinBounds())
        {
            yield return new WaitForSeconds(fireRate);
            if (distanceFromPlayer < maximumFiringRange)
            {
                EnemyFire();
            }
        }
        StartCoroutine(FireAtPlayer());
    }

    bool IsWithinBounds()
    {
        if (gameObject.transform.position.x < 8.5 && gameObject.transform.position.x > -8.5 &&
            gameObject.transform.position.y < 4.5 && gameObject.transform.position.y > -4.5)
        {
            return true;
        }
        else return false;
    }

    public virtual void EnemyFire()
    {
        //must make this
    }

    public void TakeDamage()
    {
        hp--;
        if (hp <= 0)
        {
            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {
        Destroy(this);
        //play death animation
    }
}
