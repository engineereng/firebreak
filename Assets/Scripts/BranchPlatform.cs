using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchPlatform : Plant
{
    [SerializeField] private Animator anim;
    public BoxCollider2D playerBoxCollider;
    public Sprite spriteRenderer;
    public Sprite healthySprite;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        isAlive = life > 50;
        // if (this.gameObject.tag == "NoPass")
        // {}
        // else
        // {
        //     Physics2D.IgnoreCollision(playerBoxCollider, 
        //         GetComponent<BoxCollider2D>(), 
        //         !isAlive);
        // }
        Physics2D.IgnoreCollision(playerBoxCollider, 
            GetComponent<BoxCollider2D>(), 
            !isAlive);
        anim.SetBool("BranchGrowth", isAlive);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = isAlive ? healthySprite : spriteRenderer;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit a player");
        }
    }
}
