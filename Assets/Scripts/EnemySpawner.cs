using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public float time;
    public float enemyDelay;
    public int round;
    public Text roundTextbox;
    public int score;
    public Text scoreTextbox;
    public GameObject roundScreen;
    public Text roundFinishedTextbox;
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
    public Text enemiesRemainingTextbox;

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

    IEnumerator RemainingEnemies()
    {
        yield return new WaitForSeconds(0.2f);
        enemiesRemainingTextbox.text = "Enemies Remaining: " + (maximumEnemies - enemiesKilled).ToString();
        StartCoroutine(RemainingEnemies());
    }

    IEnumerator DeductPoints()
    {
        yield return new WaitForSeconds(1.0f);
        score--;
        scoreTextbox.text = "Score: " + score.ToString();
        StartCoroutine(DeductPoints());
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
        roundTextbox.text = "Round: " + round.ToString();
        if (round < 5)
        {
            enemyDelay = 6f - (float)round;
        }
        else
        {
            enemyDelay = 1f;
        }
        enemiesKilled = 0;
        StartCoroutine(DeductPoints());
        StartCoroutine(RemainingEnemies());
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
        StopCoroutine(DeductPoints());
        StopCoroutine(RemainingEnemies());
        enemiesKilled = 0;
        EndOfRoundPoints();
        activePlayer.gameObject.SetActive(false);
        roundScreen.gameObject.SetActive(true);
        roundFinishedTextbox.text = "Firewall " + round.ToString() + " Breached";
    }

    void EndOfRoundPoints()
    {
        score += 50 * round;
    }

    public void NextRound()
    {
        round++;
        roundTextbox.text = "Round: " + round.ToString();
        activePlayer.gameObject.SetActive(true);
        if (GameObject.Find("PlayerCharacter") == null)
        {
            activePlayer.Glitch.SetActive(true);
            GameObject destr = activePlayer.gameObject;
            activePlayer = activePlayer.Glitch.GetComponent<PlayerCharacter>();
            Destroy(destr);
        }
        roundScreen.gameObject.SetActive(false);
        RoundStart();
    }

}
