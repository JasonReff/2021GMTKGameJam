using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToCredits : MonoBehaviour
{

    // Update is called once per frame
    void OnMouseDown()
    {
        Application.LoadLevel("Credits");
    }
}