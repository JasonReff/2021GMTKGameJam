using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReticle : MonoBehaviour
{
    public PlayerCharacter character;
    public Vector2 characterToReticle;
    public Rigidbody2D rb;
    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void FixedUpdate()
    {
        rb.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 8);
        characterToReticle = rb.transform.position - character.rb.transform.position;
        characterToReticle.Normalize();

    }

    public void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = (Vector2)character.rb.transform.position + characterToReticle;
        projectile.GetComponent<Rigidbody2D>().AddForce(characterToReticle * projectile.GetComponent<Projectile>().projectileForce);
    }
}
