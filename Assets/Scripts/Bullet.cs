using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;        
    }

    // TODO add hit effect
    // public GameObject hitEffect;
     void OnCollisionEnter2D (Collision2D collision)
    {
        // TODO: Spawn an effect
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy(Effector2D, 5f); //destroy the effect after 5 seconds
        Debug.Log(collision.gameObject.name);
        if (!collision.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
