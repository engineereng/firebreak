using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchPlatform : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D rb;
    private Animator anim;
    public float life = 0.0f;
    private readonly float lifeDecay = 0.05f;
    private readonly float LIFECAP = 100.0f;
    public bool isAlive = false;
    public BoxCollider2D playerBoxCollider;
    public Sprite spriteRenderer;
    public Sprite healthySprite;

    public void Heal (int healing)
    {
        life += healing;
        if (life > LIFECAP)
        {
            life = LIFECAP;
        }        
    }
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        life -= lifeDecay;
        if (life < 0)
        {
            life = 0;
        }
        isAlive = life > 50;
        Physics2D.IgnoreCollision(playerBoxCollider,
                        GetComponent<BoxCollider2D>(), 
                        !isAlive);
        ChangeColor();
        if (isAlive)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = healthySprite;
        }
        if (!isAlive)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteRenderer;
        } 
    }
    private void ChangeColor()
    {
        GetComponent<SpriteRenderer>().color = new Color (0.0f, life / LIFECAP, 0, 1.0f);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit a player");
        }
    }
}
