using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTutorial : Button
{
    void Action()
    {
        Application.LoadLevel("Tutorial");
    }
}
