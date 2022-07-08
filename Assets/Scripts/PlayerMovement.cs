using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; //Unity Speed Parameter
    private Rigidbody2D body; // integrate asset
    private Animator anim;
    private bool grounded;
	[SerializeField] public float fallMultiplier; //Better Jump
	[SerializeField] public float lowJumpMultiplier;
	public float jumpVelocity;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    //move left right
    private void Update() // User input
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
		
		//flip sprite upon left right
		if (horizontalInput > 0.01f)
			transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
		else if (horizontalInput < -0.01f)
			transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
		
		if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && grounded) //jump when grounded
			Jump();
		//set animator parameters
		anim.SetBool("Run", horizontalInput != 0); //run into idle; idle into run
		anim.SetBool("grounded", grounded); //run into jump; jump end
		body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);
		
		if (horizontalInput > 0.01f)
			transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
		else if (horizontalInput < -0.01f)
			transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
		
		if (Input.GetKey(KeyCode.Space) && grounded) //jump when grounded
			body.velocity = new Vector2(body.velocity.x, speed); 

		//Better Jump
		if (body.velocity.y < 0)
		{
			body.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
		else if (body.velocity.y > 0 && !Input.GetKey(KeyCode.Space) || !Input.GetKey(KeyCode.W))
		{
			body.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
	}
	//Jump
	private void Jump()
	{
		body.velocity = new Vector2(body.velocity.x, speed);
		anim.SetTrigger("jump");
		grounded = false;
		GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground") 
			grounded = true;
	}
}

