using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTitle : MonoBehaviour
{
    void OnMouseDown()
    {
        gameObject.transform.position += new Vector3(0f, -1.0f, 0f);
        Invoke("LoadLevel", 0.2f);
    }
    void LoadLevel()
    {
        Application.LoadLevel("Title");
    }
    void OnMouseEnter()
    {
        gameObject.transform.position += new Vector3(0f, -0.5f, 0f);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(3.54f, 4.7f);
    }
    void OnMouseExit()
    {
        gameObject.transform.position += new Vector3(0f, 0.5f, 0f);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(3.54f, 3.87f);
    }
}
