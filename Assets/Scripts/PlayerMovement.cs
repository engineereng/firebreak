using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; //Unity Speed Parameter
    private Rigidbody2d body; // integrate asset
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2d>();
        anim = GetComponent<Animator>();
    }
    //move left right
    private void Update() // User input
	{
		float horizontalInput = Input.GetAxis("Horizonatal"); # stores value
		body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);
		
		if(horizontalInput > 0.01f)
			transform.localScale = Vector3.one;
		else if (horizonatalInput < -0.01f)
			transform.localScale = new Vector3(-1,1,1);
		
		if(Input.GetKey(KeyCode.Space)) && grounded) //jump when grounded
			body.velocity = new Vector2(body.velocity.x, speed); 
			
		//set animator parameters
		anim.SetBool("run", horizontalInput != 0); //run into idle; idle into run
		anim.SetBool("grounded", grounded) //run into jump; jump end
	}
	//jump
	private void Jump()
	{
		body.velocity = new Vector2(body.velocity.x, speed);
		grounded = false;
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground") 
			grounded = true;
	}
}

