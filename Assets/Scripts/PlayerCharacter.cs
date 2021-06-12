using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCharacter : MonoBehaviour
{
    public PlayerReticle reticle;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public GameObject projectilePrefab;
    Vector2 movement;
    void Start()
    {
        transform.position = new Vector2(0, 0);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public virtual void Fire()
    {
        
    }
}
