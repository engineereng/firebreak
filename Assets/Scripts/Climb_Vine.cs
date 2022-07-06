using UnityEngine;

public class Climb_Vine : MonoBehaviour
{
	private float vertical;
	private float speed = 8f;
	private bool isVine;
	private bool isClimbing;
	
	[SerializeField] private Rigidbody2D body;
	
	void Update()
	{
		vertical = Input.GetAxis("Vertical");
		
		if (isVine && Mathf.Abs(vertical) > 0f)
		{
			isClimbing = true;
		}
	}
	
	private void FixedUpdate() //Physics
	{
		if (isClimbing)
		{
			body.gravityScale = 0f;
			body.velocity = new Vector2(body.velocity.x, vertical * speed);
		}
		else //original gravity
		{
			body.gravityScale = 4f;
		}
	}
	
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Vine"))
		{
			isVine = true;
		}
	}
	
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Vine"))
		{
			isVine = false;
			isClimbing = false;
		}
	}
}