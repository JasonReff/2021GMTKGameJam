using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float time;
    public float enemyDelay;
    public int round;
    public GameObject roundScreen;
    public PlayerCharacter activePlayer;
    public Queue<int> enemyQueue;
    public GameObject OEnemyPrefab;
    public GameObject QuestionMarkEnemyPrefab;
    public GameObject ThreeEnemyPrefab;
    public GameObject AmpersandEnemyPrefab;
    public GameObject AsteriskEnemyPrefab;
    public GameObject BracketEnemyPrefab;
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
            RoundEnd();
        }
    }

    void Start()
    {
        activePlayer = GameObject.Find("PlayerCharacter").GetComponent<PlayerCharacter>();
        enemyQueue = new Queue<int> { };
        RoundStart();
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
            int enemyID = UnityEngine.Random.Range(1, 7);
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
        GameObject currentEnemy = null;
        switch (e)
        {
            case 1:
                currentEnemy = Instantiate(OEnemyPrefab, coordinates, Quaternion.identity);
                currentEnemy.GetComponent<Enemy>().player = activePlayer.gameObject;
                break;
            case 2:
                currentEnemy = Instantiate(QuestionMarkEnemyPrefab, coordinates, Quaternion.identity);
                currentEnemy.GetComponent<Enemy>().player = activePlayer.gameObject;
                break;
            case 3:
                currentEnemy = Instantiate(ThreeEnemyPrefab, coordinates, Quaternion.identity);
                currentEnemy.GetComponent<Enemy>().player = activePlayer.gameObject;
                break;
            case 4:
                currentEnemy = Instantiate(AmpersandEnemyPrefab, coordinates, Quaternion.identity);
                currentEnemy.GetComponent<Enemy>().player = activePlayer.gameObject;
                break;
            case 5:
                currentEnemy = Instantiate(AsteriskEnemyPrefab, coordinates, Quaternion.identity);
                currentEnemy.GetComponent<Enemy>().player = activePlayer.gameObject;
                break;
            case 6:
                currentEnemy = Instantiate(BracketEnemyPrefab, coordinates, Quaternion.identity);
                currentEnemy.GetComponent<Enemy>().player = activePlayer.gameObject;
                break;
        }
    }

    void RoundEnd()
    {
        activePlayer.gameObject.SetActive(false);
    }

    public void NextRound()
    {
        round++;
        activePlayer.gameObject.SetActive(true);
        RoundStart();
    }

}
