using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel3 : MonoBehaviour {
	
	//public GlobalAmmo ammo;									// Use the getAmmo() function

	private int saveScore;										// Save the score from level 1 going into level 2
	//private int saveAmmo;										// Save the ammo from level 1 to use in level 2
	private int saveHealth;										// Save Player hearlth from level 1 to level 2

	GameObject player;

	/*
	 * When the player is finished the game quit
	*/
	public void EndTheGame() {
		player = GameObject.FindWithTag ("Player");

		saveHealth = player.GetComponent<PlayerHealth> ().getPlayerHealth ();	// Get the Player health

		saveScore = GetComponent<ManageScore> ().getScore ();				// Get the Score

		PlayerPrefs.SetInt ("Score", saveScore);				// Save the score value
		//PlayerPrefs.SetInt ("Ammo", saveAmmo);				// Save the ammo amount
		PlayerPrefs.SetInt ("Health", saveHealth);				// Save the health value

		//SceneManager.LoadScene (2);								// Load The menu
	}

	public void SaveState(){
		Debug.Log ("Player Died - Save Stage");

		EndTheGame ();
	}
}