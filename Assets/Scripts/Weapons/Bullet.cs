using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Transform playerTrans;
    public float lifetime = 3f;
    public float bulletSpeed = 20f;
    public int damage;
    public Rigidbody2D rb;
    //public Vector2 direction = gunner.rotation;

    // Start is called before the first frame update
    void Awake() {
        rb.velocity = transform.up  * bulletSpeed;
        Destroy(gameObject, lifetime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            return;
        if (collision.GetComponent<HealthScript>())
        {
            // cb = FindObjectOfType<CrimeBroadcast>();
            // cb?.Broadcast();
            collision.GetComponent<HealthScript>().OnDamageTaken(damage, transform.forward, playerTrans);
            Destroy(gameObject);
        }
    }
}
