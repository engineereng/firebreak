using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision) //track anything that enters in the zone
	{
		if(collision.tag == "Player") //if player collides with the object
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Increase scene by 1. buildIndex found in Build Settings. Order them correctly. Right side of each scene (0, 1, 2..) is buildIndex.
		
		}
	}
}
