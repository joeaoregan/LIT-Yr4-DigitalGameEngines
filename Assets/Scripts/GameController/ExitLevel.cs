// Joe O'Regan
// Stuff to do at the end of and between levels
// Save state, and decide which level to load next, if any

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour {
	
	//public GlobalAmmo ammo;														// Use the getAmmo() function

	private int saveScore;														// Save the score from level 1 going into level 2
	private int saveAmmo;														// Save the ammo from level 1 to use in level 2
	private int saveHealth;														// Save Player hearlth from level 1 to level 2

	GameObject player;

	/*
	 * When the player is finished the game quit
	*/
	public void ProgressLevels() {
		SaveState ();

		if (SceneManager.GetActiveScene ().buildIndex == 3)
			SceneManager.LoadScene (4);											// Load Level 2
		else if (SceneManager.GetActiveScene ().buildIndex == 4)
			SceneManager.LoadScene (5);											// Load Level 3
	}

	public void SaveState(){
		player = GameObject.FindWithTag ("Player");

		saveHealth = player.GetComponent<PlayerHealth> ().getPlayerHealth ();	// Get the Player health
		//saveAmmo = ammo.CurrentAmmo;											// Get the Players ammo
		saveAmmo = GetComponent<ManageAmmo>().GetAmmo();						// Get the Players ammo
		saveScore = GetComponent<ManageScore> ().getScore ();					// Get the Score

		PlayerPrefs.SetInt ("Score", saveScore);								// Save the score value
		PlayerPrefs.SetInt ("Ammo", saveAmmo);									// Save the ammo amount
		PlayerPrefs.SetInt ("Health", saveHealth);								// Save the health value

		Debug.Log("<color=orange>Save State: </color>Score: " + saveScore + " Ammo: " + saveAmmo + " Health: " + saveHealth);
	}
}