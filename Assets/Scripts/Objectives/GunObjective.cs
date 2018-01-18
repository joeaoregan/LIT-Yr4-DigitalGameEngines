// Joe O'Regan
// Level 1
// Objective 1: Find the gun
// What to do after this has finished
// Set up objective 2
// Cutaway to show where the ammo is in the target room

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunObjective : MonoBehaviour {

	//public Text actionText;															// Canvas action text
	//public ObjectiveCounter objectiveCounter;											// Amount of completed objectives

	// Camera view for objectives
	public Camera shootingRangeCam;														// Shooting range camera
	public Camera fpsCam;																// FPS controller camera
	public Canvas playerHUD;															// Disable Player HUD canvas when changing cameras

	// CCTV screen hints
	public Text gunIsHereText;
	public Text ammoIsHereText;

	private Text infoMsg;																// Replaces actionText

	private GameObject gc;																// Game controller

	bool done;

	// Use this for initialization
	void Start () {
		gc = GameObject.FindWithTag ("GameController");									// Locate the game controller
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();			// Find the information message object

		done = false;
		//StartCoroutine ("ObjectiveComplete");
		//objectiveCounter.incrementObjectives ();										// Increment the number of complete objectives // Moved to ObjectiveComplete
	}

	void Update(){
		if (gc.GetComponent<ManageObjectives>().GetObjective1Complete() && !done) {		// If the player has the gun
			//StartCoroutine ("ObjectiveComplete");	

			StartCoroutine (Objective1Complete ());					
		}
	}

	IEnumerator Objective1Complete () {
		Debug.Log ("GunObjective.cs: Objective 1 Complete");	

		done = true;																	// Stop looping through the same function over and over

		gunIsHereText.enabled = false;													// Turn off CCTV hint for gun location
		ammoIsHereText.enabled = true;													// Turn on CCTV hint for ammo location

		infoMsg.GetComponent<Text> ().text = "Objective 1:\nFind Gun Complete";			// Display message
		yield return new WaitForSeconds (2);											// Wait for the amount of time
		infoMsg.GetComponent<Text> ().text = "";										// Need to clear previous message or it writes over with camera change
		yield return new WaitForSeconds (0.5f);											// Wait for the amount of time to allow the text to be cleared
		infoMsg.GetComponent<Text> ().text = "Objective 2:\nFind Ammo";					// Then clear the message
		StartCoroutine ("CameraViewport");												// Switch cameras
		yield return new WaitForSeconds (2);											// Wait for the amount of time
		infoMsg.GetComponent<Text> ().text = "";										// Then clear the message

	}

	IEnumerator CameraViewport () {
		ShowShootingRange ();			 												// Show the shooting range camera in viewport
		yield return new WaitForSeconds (2);											// Wait for the amount of time
		ShowFPSCam();																	// Return to the FPS camera
	}

	private void ShowShootingRange() {
		playerHUD.enabled = false;														// Turn off the Player HUD canvas
		fpsCam.enabled = false;															// Turn off the FPS camera
		shootingRangeCam.enabled = true;												// Turn on the shooting range camera
	}

	private void ShowFPSCam(){
		playerHUD.enabled = true;														// Turn back on the Player HUD canvas
		shootingRangeCam.enabled = false;												// Turn off the shooting range camera
		fpsCam.enabled = true;															// Turn on the FPS camera
	}
}
