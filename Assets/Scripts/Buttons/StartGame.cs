using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : Button
{
    void Action()
    {
        Application.LoadLevel("Game");
    }
}
