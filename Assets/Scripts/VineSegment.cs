using UnityEngine;

public class VineSegment : BranchPlatform
{
    [SerializeField] float offsetDown = 0, offsetUp = 0, speed = 1;
    public Rigidbody2D rb;
    Vector2 startPosition = Vector2.zero;
//     private float decayDelay = 0;
    void Awake()
    {
        startPosition = transform.position;
    }
    void FixedUpdate()
    {
        Physics2D.IgnoreCollision(playerBoxCollider,
                        GetComponent<BoxCollider2D>(), 
                        !isAlive); 
        // adapted from https://pavcreations.com/moving-platforms-in-a-2d-side-scroller-unity-game/
        if (isAlive && transform.position.y > startPosition.y + offsetDown) 
                Move(offsetDown);
        else
            Move(offsetUp);
    }  

    void Move(float offset)
    {
        transform.position = Vector2.MoveTowards(transform.position,
                                                 new Vector2(startPosition.x,
                                                        startPosition.y + offset),
                                                 speed * Time.deltaTime);
    }
}
