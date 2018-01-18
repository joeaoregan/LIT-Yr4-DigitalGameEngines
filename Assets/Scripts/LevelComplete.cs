// Joe O'Regan
// Levels 1 and 2
// Handle Progressing Between Levels When Level Complete

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

	public Animator levelCompleteAnimation;
	public Canvas playerHUD;

	GameObject player;
	GameObject gc;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");   	// Locate the Player
		gc = GameObject.FindGameObjectWithTag ("GameController");   // Locate the Game Controller
	}

	// When the player enters the trigger point, load level 3
	void OnTriggerEnter (Collider other)                        	// Called whenever anything goes into a trigger
	{
		if(other.gameObject == player)                          	// Make sure it is the player we are attacking
		{
			if (SceneManager.GetActiveScene().buildIndex == 3)
				Debug.Log ("Level 1 Complete");
			else if (SceneManager.GetActiveScene().buildIndex == 4)
				Debug.Log ("Level 2 Complete");
			
			gc.GetComponent<ExitLevel> ().SaveState ();				// Save state between levels

			//SceneManager.LoadScene(5);							// Load level 3

			playerHUD.enabled = false;
			levelCompleteAnimation.SetTrigger("Fade");
		}
	}
}
