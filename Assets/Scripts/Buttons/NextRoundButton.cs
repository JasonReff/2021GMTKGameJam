using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this does not inherit the button class, but should it?
public class NextRoundButton : MonoBehaviour
{
    public EventSystem enemySpawner;
    public GameObject roundScreen;
    private void OnMouseDown()
    {
        roundScreen.SetActive(false);
        enemySpawner.NextRound();
    }

}
