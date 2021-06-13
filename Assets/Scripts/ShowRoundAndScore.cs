using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRoundAndScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        roundTextbox.text = "Round: " + PlayerPrefs.GetInt("round", eSpawn.GetComponent<EnemySpawner>().round).ToString();
        PlayerPrefs.GetInt("score", eSpawn.GetComponent<EnemySpawner>().score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
