using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : Button
{
    void Action()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}