using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPickup : MonoBehaviour
{
    public int data;
    public float timeOnScreen;

    private void Awake()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(timeOnScreen);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Pickup();
    }

    public void Pickup()
    {
        EventSystem.current.score += data * 5;
        UpgradeSystem.current.currentData += data;
        Destroy(gameObject);
    }
}
