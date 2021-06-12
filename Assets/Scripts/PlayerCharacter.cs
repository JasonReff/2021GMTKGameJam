using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCharacter : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public GameObject OCorruptPrefab;
    public GameObject QuestionMarkCorruptPrefab;
    public GameObject AmpersandCorruptPrefab;
    public GameObject ThreeCorruptPrefab;

    Vector2 movement;
    void Start()
    {
        transform.position = new Vector2(0, 0);
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerCollision(collision);
    }

    public virtual void PlayerCollision(Collision2D collision)
    {
        int corruptNumber = collision.collider.gameObject.GetComponent<Enemy>().id;
        Destroy(collision.collider.gameObject);
        switch (corruptNumber)
        {
            case 1:
                GameObject oCorrupt = Instantiate(OCorruptPrefab, gameObject.transform.position, Quaternion.identity);
                break;
            case 2:
                GameObject questionMarkCorrupt = Instantiate(QuestionMarkCorruptPrefab, gameObject.transform.position, Quaternion.identity);
                break;
            case 3:
                GameObject threeCorrupt = Instantiate(ThreeCorruptPrefab, gameObject.transform.position, Quaternion.identity);
                break;
            case 4:
                GameObject ampersandCorrupt = Instantiate(AmpersandCorruptPrefab, gameObject.transform.position, Quaternion.identity);
                break;
        }
        gameObject.SetActive(false);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
