using UnityEngine;

public class CorruptPlayer : PlayerCharacter
{

    public override void Start()
    {
        fireDelay /= UpgradeSystem.current.fireRateMultiplier;
        moveSpeed *= UpgradeSystem.current.movementSpeedMultiplier;
        corruptLifespan *= UpgradeSystem.current.lifespanMultiplier;
        anim.SetBool("Corrupt", true);
        Invoke("StopAnimation", .8f);
        StartCoroutine(LifespanTick());
    }

    public void StopAnimation()
    {
        anim.SetBool("Corrupt", false);
    }

    public override void PlayerCollision(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<DataPickup>() != null)
        {
            return;
        }
        if (collision.collider.gameObject.GetComponent<Enemy>() != null)
        {
            collision.collider.gameObject.GetComponent<Enemy>().EnemyDies();
        }
        Uncorrupt();
    }

    public override void Uncorrupt()
    {
        Glitch.SetActive(true);
        Glitch.transform.position = gameObject.transform.position;
        EventSystem.current.activePlayer = Glitch.GetComponent<PlayerCharacter>();
        Destroy(gameObject);
        Glitch.GetComponent<PlayerCharacter>().Uncorrupt();
    }

    public virtual void ShootProjectileWithForce(GameObject projectilePrefab, Vector2 direction)
    {
        Vector3 currentPosition = transform.position;
        float bulletForce = projectilePrefab.GetComponent<Projectile>().projectileForce;
        float bulletForceMultiplier = UpgradeSystem.current.bulletForceMultiplier;
        bulletForce = bulletForce * bulletForceMultiplier;
        GameObject newProjectile = Instantiate(projectilePrefab, currentPosition + (Vector3)direction, Quaternion.identity);
        newProjectile.GetComponent<Rigidbody2D>().AddForce(direction * bulletForce);
    }

}
