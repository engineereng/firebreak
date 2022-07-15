using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchPlatform : Plant
{
    private Animator anim;

    public BoxCollider2D playerBoxCollider;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        isAlive = life > 50;
        Physics2D.IgnoreCollision(playerBoxCollider,
                        GetComponent<BoxCollider2D>(), 
                        !isAlive);        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit a player");
        }
    }
}
