using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunObjective : MonoBehaviour {

	public Text actionText;																// Canvas action text
	public ObjectiveCounter objectiveCounter;											// Amount of completed objectives

	// Camera view for objectives
	public Camera shootingRangeCam;														// Shooting range camera
	public Camera fpsCam;																// FPS controller camera
	public Canvas playerHUD;															// Disable Player HUD canvas when changing cameras

	// CCTV screen hints
	public Text gunIsHereText;
	public Text ammoIsHereText;

	// Use this for initialization
	void Start () {
		StartCoroutine ("ObjectiveComplete");
		objectiveCounter.incrementObjectives ();										// Increment the number of complete objectives
		gunIsHereText.enabled = false;													// Turn off CCTV hint for gun location
		ammoIsHereText.enabled = true;													// Turn on CCTV hint for ammo location
	}
	
	// Update is called once per frame
	IEnumerator ObjectiveComplete () {
		actionText.GetComponent<Text> ().text = "Objective 1:\nFind Gun Complete";		// Display message
		yield return new WaitForSeconds (2);											// Wait for the amount of time
		actionText.GetComponent<Text> ().text = "";										// Need to clear previous message or it writes over with camera change
		yield return new WaitForSeconds (0.5f);											// Wait for the amount of time to allow the text to be cleared
		actionText.GetComponent<Text> ().text = "Objective 2:\nFind Ammo";				// Then clear the message
		StartCoroutine ("CameraViewport");												// Switch cameras
		yield return new WaitForSeconds (2);											// Wait for the amount of time
		actionText.GetComponent<Text> ().text = "";										// Then clear the message
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
