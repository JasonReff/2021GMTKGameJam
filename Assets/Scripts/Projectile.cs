using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float projectileForce;
    public float rangeInSeconds;
    public float time;

    private void Awake()
    {
        rangeInSeconds *= UpgradeSystem.current.bulletRangeMultiplier;
        time = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.collider.gameObject.GetComponent<Enemy>() != null)
            {
                collision.collider.gameObject.GetComponent<Enemy>().EnemyDies();
            }
            else if (collision.collider.gameObject.GetComponent<PlayerCharacter>() != null)
            {
                if (collision.collider.gameObject.GetComponent<PlayerCharacter>().invincible)
                {
                    
                }
                else 
                {
                    collision.collider.gameObject.GetComponent<PlayerCharacter>().PlayerDeath();
                }
            }
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= rangeInSeconds)
        {
            Destroy(gameObject);
        }
    }

}
