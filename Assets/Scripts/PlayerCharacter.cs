using System.Collections;
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
    public static PlayerCharacter Glitch;
    public bool readyToFire = true;
    public float fireDelay;
    public float corruptLifespan;
    public float invincibilityTime;
    public bool invincible;
    public int lives;
    Vector2 movement;

    public virtual void Start()
    {
        Glitch = this;
        transform.position = new Vector2(0, 0);
    }

    public virtual void Awake()
    {

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerCollision(collision);
    }

    public virtual void PlayerCollision(Collision2D collision)
    {
        if (invincible)
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), collision.collider.GetComponent<BoxCollider2D>());
            return;
        }
        if (IsEnemyDamage(collision))
        {
            PlayerDamage();
            return;
        }
        if (IsPickup(collision))
        {
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
            PlayerCharacter newCorruptPlayer = corruptPlayer.GetComponent<PlayerCharacter>();
            CorruptEnemy(newCorruptPlayer);
        }
        gameObject.SetActive(false);
    }

    public void CorruptEnemy(PlayerCharacter corruptPlayer)
    {
        corruptPlayer.reticle = reticle;
        corruptPlayer.audioSource = audioSource;
        EventSystem.current.CorruptEnemy(corruptPlayer);
    }

    bool IsEnemyDamage(Collision2D collision)
    {
        if (collision.collider.GetComponent<Projectile>() != null)
        {
            return true;
        }
        else return false;
    }

    bool IsPickup(Collision2D collision)
    {
        if (collision.collider.GetComponent<DataPickup>() != null)
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

    public virtual IEnumerator LifespanTick()
    {
        float time = 0;
        while (time < corruptLifespan) 
        {
            time += 0.1f;
            yield return new WaitForSeconds(0.1f);
            if (time == 2.0f)
            {
                StartCoroutine(LifespanAnimation());
            }
        }
        Uncorrupt();
    }

    public virtual IEnumerator LifespanAnimation()
    {
        anim.SetBool("hit", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("hit", false);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("hit", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("hit", false);
    }

    public virtual void Uncorrupt()
    {
        StartCoroutine(IFrames());
    }

    public IEnumerator IFrames()
    {
        invincible = true;
        StartCoroutine(IFrameAnimation());
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
    }

    public IEnumerator IFrameAnimation()
    {
        anim.SetBool("hit", true);
        yield return new WaitForSeconds(invincibilityTime);
        anim.SetBool("hit", false);
    }

    public void PlayerDamage()
    {
        lives--;
        EventSystem.current.combatLivesTextbox.text = $"Lives: {lives}";
        if (lives < 0)
        {
            PlayerDeath();
            return;
        }
        StartCoroutine(IFrames());
    }

    public void PlayerDeath()
    {
        audioSource.clip = deathSound;
        audioSource.Play();
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2 (0, 0);
        Invoke("GameOver", 2f);
        anim.SetBool("dead", true);
        PlayerPrefs.SetInt("score", EventSystem.current.score);
        PlayerPrefs.SetInt("round", EventSystem.current.round);
    }

    public void GameOver()
    {
        Application.LoadLevel("GameOver");
    }
}
