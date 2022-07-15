using UnityEngine;

public class Climb_Vine : MonoBehaviour
{
	private float vertical;
	private readonly float speed = 8f;
	public bool isVine;
	public bool isClimbing;
	
	[SerializeField] private Rigidbody2D body;
	
	void Update()
	{
		vertical = Input.GetAxis("Vertical");
		
		if (!isVine)
		{
			isClimbing = false;
		} else if (Mathf.Abs(vertical) > 0f)
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
		VineSegment vine = collision.GetComponent<VineSegment>();
		if (vine != null)
		{
			isVine = vine.isAlive;
		}
	}

	private void OnTriggerStay2D (Collider2D collision)
	{
		VineSegment vine = collision.GetComponent<VineSegment>();
		if (vine != null)
		{
			isVine = vine.isAlive;
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