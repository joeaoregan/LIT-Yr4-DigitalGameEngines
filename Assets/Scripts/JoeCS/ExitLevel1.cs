using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel1 : MonoBehaviour {

	public ManageScore score;						// Use the getScore() function
	public GlobalAmmo ammo;							// Use the getAmmo() function

	private int saveScore;							// Save the score from level 1 going into level 2
	private int sameAmmo;							// Save the ammo from level 1 to use in level 2

	/*
	 * When the player enters the doorway trigger
	 * Load level 2
	*/
	void OnTriggerEnter(Collider other){
		saveScore = score.getScore ();				// Get the score
		sameAmmo = ammo.getAmmo ();					// Get the ammo
		PlayerPrefs.SetInt ("Score", saveScore);	// Save the score
		PlayerPrefs.SetInt ("Ammo", sameAmmo);		// Save the ammo

		//SceneManager.LoadScene (2);				// Load Level 2
		SceneManager.LoadScene (4);					// Load Level 2 (intro, and enter name scenes added)
	}
}