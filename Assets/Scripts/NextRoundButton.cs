using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoundButton : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public GameObject roundScreen;
    private void OnMouseDown()
    {
        roundScreen.SetActive(false);
        enemySpawner.NextRound();
    }

}
