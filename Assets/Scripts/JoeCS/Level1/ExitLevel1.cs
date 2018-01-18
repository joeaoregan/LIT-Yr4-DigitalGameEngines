using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel1 : MonoBehaviour {

	//public ManageScore score;									// Use the getScore() function
	public GlobalAmmo ammo;										// Use the getAmmo() function

	private int saveScore;										// Save the score from level 1 going into level 2
	private int saveAmmo;										// Save the ammo from level 1 to use in level 2
	private int saveHealth;										// Save Player hearlth from level 1 to level 2

	GameObject player;

	void Start (){
		player = GameObject.FindWithTag ("Player");
	}

	// When the player enters the doorway trigger load level 2
	public void SaveState() {
		saveHealth = player.GetComponent<PlayerHealth> ().getPlayerHealth ();	// Get the Player health
		saveScore = GetComponent<ManageScore> ().getScore ();					// Get the Score
		//saveScore = score.getScore ();										// Get the score
		saveAmmo = ammo.getAmmo ();												// Get the ammo

		PlayerPrefs.SetInt ("Score", saveScore);								// Save the score value
		PlayerPrefs.SetInt ("Ammo", saveAmmo);									// Save the ammo amount
		PlayerPrefs.SetInt ("Health", saveHealth);								// Save the health value

		Debug.Log ("Score: " + saveScore + " Ammo: " + saveAmmo + " Health: " + saveHealth);

		//SceneManager.LoadScene (2);											// Load Level 2
		//SceneManager.LoadScene (4);												// Load Level 2 (intro, and enter name scenes added)
	}


}