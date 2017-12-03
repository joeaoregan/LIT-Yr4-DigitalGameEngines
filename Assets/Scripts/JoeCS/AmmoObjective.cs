using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoObjective : MonoBehaviour {

	public Text actionText;																		// Canvas action text
	public ObjectiveCounter objectiveCounter;													// Number of objectives completed

	public Camera rangeCam;																		// Camera positioned in Shooting Range
	public Camera playerCam;																	// FPS camera

	// Use this for initialization
	void Start () {
		StartCoroutine ("ObjectiveComplete");
		objectiveCounter.incrementObjectives ();												// Increment the number of complete objectives
	}
	
	// Update is called once per frame
	IEnumerator ObjectiveComplete () {
		actionText.GetComponent<Text> ().text = "Objective 2:\nFind Ammo For Gun Complete";		// Display objective complete message
		yield return new WaitForSeconds (2);													// Wait for the amount of time
		actionText.GetComponent<Text> ().text = "";												// Need to clear previous message or it writes over with camera change
		yield return new WaitForSeconds (0.5f);													// Wait for the amount of time to allow the text to be cleared
		actionText.GetComponent<Text> ().text = "Objective 3:\nDestroy 4 Shooting Range Targets";// Then display the next objective
		StartCoroutine ("CameraViewport");														// Switch cameras
		yield return new WaitForSeconds (2);													// Wait for the amount of time
		actionText.GetComponent<Text> ().text = "";												// Then clear the message
	}

	IEnumerator CameraViewport () {
		ShowShootingRange ();			 														// Show the shooting range camera in viewport
		yield return new WaitForSeconds (2);													// Wait for the amount of time
		ShowFPSCam();																			// Return to the FPS camera
	}

	private void ShowShootingRange() {
		playerCam.enabled = false;																// Turn off the FPS camera
		rangeCam.enabled = true;																// Turn on the shooting range camera
	}

	private void ShowFPSCam(){
		rangeCam.enabled = false;																// Turn off the shooting range camera
		playerCam.enabled = true;																// Turn on the FPS camera
	}
}
