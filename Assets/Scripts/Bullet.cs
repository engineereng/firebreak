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
        Destroy(gameObject, 5.0f);    
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (!other.gameObject.CompareTag("Player"))
        {
            Plant plant = other.gameObject.GetComponent<Plant>();
                if (plant != null)
                {
                    plant.Heal(10);
                    Debug.Log("Hit a plant!");
                }
            Destroy(gameObject);
        }
    }

    // // TODO add hit effect
    // // public GameObject hitEffect;
     void OnCollisionEnter2D (Collision2D collision)
    {
        // TODO: Spawn an effect

        Debug.Log(collision.gameObject.name);
        if (!collision.gameObject.CompareTag("Player"))
        {
            Plant plant = collision.gameObject.GetComponent<Plant>();
            if (plant != null)
            {
                plant.Heal(10);
                Debug.Log("Hit a plant!");
            }
            Destroy(gameObject);
        }
    }
}
