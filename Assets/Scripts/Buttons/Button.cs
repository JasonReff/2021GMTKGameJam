using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    //look mom I did inheritance
    public void OnMouseDown()
    {
        gameObject.transform.position += new Vector3(0f, -1.0f, 0f);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(3.54f, 6.7f);
        Invoke("Action", 0.2f);
    }
    public virtual void Action()
    {
    }
    public void OnMouseEnter()
    {
        gameObject.transform.position += new Vector3(0f, -0.5f, 0f);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(3.54f, 4.7f);
    }
    public void OnMouseExit()
    {
        gameObject.transform.position += new Vector3(0f, 0.5f, 0f);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(3.54f, 3.87f);
    }
}
