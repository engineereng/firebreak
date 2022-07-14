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

        Debug.Log(collision.gameObject.name);
        if (!collision.gameObject.CompareTag("Player"))
        {
            // if (collision.gameObject.CompareTag("Plant")) {
                //spawn hit effect
                Plant plant = collision.gameObject.GetComponent<Plant>();
                if (plant != null)
                {
                    plant.Heal(10);
                    Debug.Log("Hit a plant!");
                }
                // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                // Destroy(Effector2D, 5f); //destroy the effect after 5 seconds
            // }

                BranchPlatform branch = collision.gameObject.GetComponent<BranchPlatform>();
                if (branch != null)
                {
                    branch.Heal(10);
                    Debug.Log("Hit a branch!");
                }
            Destroy(gameObject);
        }
    }
}
