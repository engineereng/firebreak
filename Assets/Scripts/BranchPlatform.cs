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
        ChangeColor();
    }
    private void ChangeColor()
    {
        GetComponent<SpriteRenderer>().color = new Color (0.0f, life / LIFECAP, 0, 1.0f);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (life > 50 && collision.gameObject.tag == "Player")
        {
            //Physics.IgnoreCollision(GetComponent<Collider>(), true);
            GetComponent<BoxCollider2D> ().enabled = false;
        }
        if (life <= 50 && collision.gameObject.tag == "Player")
        {
            //Physics.IgnoreCollision(Branch.collider2D, GetComponent<Collider>(), false);
            GetComponent<BoxCollider2D> ().enabled = true;
        }
    }
}
