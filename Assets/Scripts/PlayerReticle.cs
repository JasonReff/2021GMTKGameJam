using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReticle : MonoBehaviour
{

    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        rb.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 8);
    }
}