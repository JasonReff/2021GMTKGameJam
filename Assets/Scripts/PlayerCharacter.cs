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
    public GameObject OCorruptPrefab;
    public GameObject QuestionMarkCorruptPrefab;
    public GameObject AmpersandCorruptPrefab;
    public GameObject ThreeCorruptPrefab;
    public GameObject AsteriskCorruptPrefab;
    public GameObject BracketCorruptPrefab;
    public GameObject projectilePrefab;
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
        if (IsEnemyShielded(collision))
        {
            PlayerDeath();
            return;
        }
        int corruptNumber = 0;
        if (collision.collider.gameObject.GetComponent<Enemy>() != null)
        {
            corruptNumber = collision.collider.gameObject.GetComponent<Enemy>().id;
        }
        Destroy(collision.collider.gameObject);
        GameObject corruptPlayer = null;
        switch (corruptNumber)
        {
            case 1:
                corruptPlayer = Instantiate(OCorruptPrefab, this.gameObject.transform.position, Quaternion.identity);
                break;
            case 2:
                corruptPlayer = Instantiate(QuestionMarkCorruptPrefab, this.gameObject.transform.position, Quaternion.identity);
                break;
            case 3:
                corruptPlayer = Instantiate(ThreeCorruptPrefab, this.gameObject.transform.position, Quaternion.identity);
                break;
            case 4:
                corruptPlayer = Instantiate(AmpersandCorruptPrefab, this.gameObject.transform.position, Quaternion.identity);
                break;
            case 5:
                corruptPlayer = Instantiate(AsteriskCorruptPrefab, this.gameObject.transform.position, Quaternion.identity);
                break;
            case 6:
                corruptPlayer = Instantiate(BracketCorruptPrefab, this.gameObject.transform.position, Quaternion.identity);
                break;
        }
        if (corruptPlayer != null)
        {
            corruptPlayer.GetComponent<PlayerCharacter>().reticle = reticle;
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().activePlayer = corruptPlayer.GetComponent<PlayerCharacter>();
        }
        gameObject.SetActive(false);
    }

    bool IsEnemyShielded(Collision2D collision)
    {
        if (collision.collider.GetComponent<BracketEnemy>() != null) 
        {
            if (collision.collider.GetComponent<BracketEnemy>().isShieldOn)
            {
                return true;
            }
            else return false;
        }
        else return false;
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
        Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        if (IsWithinBounds(newPosition))
        {
            rb.MovePosition(newPosition);
        }
    }

    bool IsWithinBounds(Vector2 position)
    {
        if (position.y < 4.5 && position.y > -4.5 && position.x < 8.5 && position.x > -8.5)
        {
            return true;
        }
        else return false;
    }

    public virtual void Fire()
    {
        
    }

    public void PlayerDeath()
    {

    }
}
