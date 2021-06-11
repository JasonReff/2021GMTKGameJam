using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int time;
    public int round;
    public Queue<int> enemyQueue;
    public GameObject OEnemyPrefab;
    void RoundStart()
    {
        time = 0;
        GenerateEnemyQueue();
    }

    void GenerateEnemyQueue()
    {
        for (int i = 0; i <= round*10; i++)
        {
            int enemyID = UnityEngine.Random.Range(1, 2);
            enemyQueue.Enqueue(enemyID);
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
        Vector2 cordinates = new Vector2(xCord, yCord);
        switch (e)
        {
            case 1:
                Instantiate(OEnemyPrefab, cordinates, Quaternion.identity); 
                break;
        }
    }
}
