using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Animator anim;
    public AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip deathSound;
    public GameObject Glitch;
    public bool readyToFire = true;
    public float fireDelay;
    Vector2 movement;
    public virtual void Start()
    {
        transform.position = new Vector2(0, 0);
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerCollision(collision);
    }

    public virtual void PlayerCollision(Collision2D collision)
    {
        if (IsEnemyDamage(collision))
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
            corruptPlayer.GetComponent<PlayerCharacter>().audioSource = audioSource;
            corruptPlayer.GetComponent<PlayerCharacter>().Glitch = gameObject;
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().activePlayer = corruptPlayer.GetComponent<PlayerCharacter>();
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().enemiesKilled++;
        }

        gameObject.SetActive(false);
    }

    bool IsEnemyDamage(Collision2D collision)
    {
        if (collision.collider.GetComponent<Projectile>() != null)
        {
            return true;
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

    public virtual IEnumerator FireRecharge()
    {
        yield return new WaitForSeconds(fireDelay);
        readyToFire = true;
    }

    public void PlayerDeath()
    {
        audioSource.clip = deathSound;
        audioSource.Play();
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2 (0, 0);
        Invoke("GameOver", 2f);
        anim.SetBool("dead", true);
    }

    public void GameOver()
    {
        Application.LoadLevel("GameOver");
    }
}
