using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
	public float life = 0.0f;
    private readonly float lifeDecay = 0.05f;
    private readonly float LIFECAP = 100.0f;
	public bool isAlive = false;
	public bool isRestored;
	public BoxCollider2D playerBoxCollider;
    
	public void Heal (int healing)
    {
        life += healing;
        if (life > LIFECAP)
        {
            life = LIFECAP;
        }        
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
		isRestored = (life >= 99);
		if (isRestored)
		{
			NextLevel();
		}
    }
    private void ChangeColor()
    {
        GetComponent<SpriteRenderer>().color = new Color (0.0f, life / LIFECAP, 0, 1.0f);
    }
	private void NextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	// private void OnTriggerEnter2D(Collider2D collision) //track anything that enters in the zone
	// {
	// 	if(collision.tag == "Player") //if player collides with the object
	// 	{
	// 		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Increase scene by 1. buildIndex found in Build Settings. Order them correctly. Right side of each scene (0, 1, 2..) is buildIndex.
		
	// 	}
	// }
}
