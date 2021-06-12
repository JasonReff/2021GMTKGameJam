using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float time;
    public float enemyDelay;
    public int round;
    public PlayerCharacter activePlayer;
    public Queue<int> enemyQueue;
    public GameObject OEnemyPrefab;
    public int enemiesKilled;
    public int maximumEnemies;

    void Update()
    {
        time += Time.deltaTime;
        if(time > enemyDelay)
        {
            time = 0;
            GetNextEnemy();
        }
        if (enemiesKilled == maximumEnemies)
        {
            //RoundEnd();
        }
    }

    void Start()
    {
        activePlayer = GameObject.Find("PlayerCharacter").GetComponent<PlayerCharacter>();
        enemyQueue = new Queue<int> { };
        PhysicsCollisionAdjustment();
        RoundStart();
    }

    void PhysicsCollisionAdjustment()
    {
        Physics.IgnoreLayerCollision(8, 9);
        Physics.IgnoreLayerCollision(8, 8);
        Physics.IgnoreLayerCollision(9, 9);
        Physics.IgnoreLayerCollision(6, 8);
        Physics.IgnoreLayerCollision(7, 9);
    }

    void RoundStart()
    {
        time = 0;
        if (round < 5)
        {
            enemyDelay = 6f - (float)round;
        }
        else
        {
            enemyDelay = 1f;
        }
        enemiesKilled = 0;
        GenerateEnemyQueue();
    }

    void GenerateEnemyQueue()
    {
        maximumEnemies = round * 10;
        for (int i = 0; i < maximumEnemies; i++)
        {
            int enemyID = UnityEngine.Random.Range(1, 2);
            enemyQueue.Enqueue(enemyID);
        }
    }

    void GetNextEnemy()
    {
        if (enemyQueue.Count > 0)
        {
            SpawnEnemy(enemyQueue.Dequeue());
        }
    }

    void SpawnEnemy(int e)
    {
        int wall = UnityEngine.Random.Range(1, 5);
        int xCord = 0;
        int yCord = 0;
        switch (wall)
        {
            case 1:
                yCord = 6;
                xCord = UnityEngine.Random.Range(-10, 10);
                break;
            case 2:
                yCord = -6;
                xCord = UnityEngine.Random.Range(-10, 10);
                break;
            case 3:
                xCord = 10;
                yCord = UnityEngine.Random.Range(-6, 6);
                break;
            case 4:
                xCord = -10;
                yCord = UnityEngine.Random.Range(-6, 6);
                break;
        }
        Vector2 coordinates = new Vector2((float)xCord, (float)yCord);
        switch (e)
        {
            case 1:
                GameObject oEnemy = Instantiate(OEnemyPrefab, coordinates, Quaternion.identity);
                oEnemy.GetComponent<Enemy>().player = activePlayer.gameObject;
                break;
        }
    }
}
