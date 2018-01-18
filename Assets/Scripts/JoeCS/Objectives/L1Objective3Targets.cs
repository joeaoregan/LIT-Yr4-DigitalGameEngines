using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L1Objective3Targets : MonoBehaviour {

	//public Text actionText;																// Canvas action text
	public ObjectiveCounter objectiveCounter;												// Number of objectives completed

	public Camera zombieCam;																// Camera positioned overlooking zombies in sleeping quarters
	public Camera playerCam;																// FPS camera

	public Canvas playerHUD;																// Turn on/off player HUD when switching camera views

	public Text targetHintText;																// Display hint on CCTV screen in storage area (ammo and target use same camera)
	public Text zombieHintText;																// Display hint on CCTV screen in storage area

	private Text infoMsg;																	// Replaces actionText			

	// Use this for initialization
	void Start () {
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();				// Find the information message object
		StartCoroutine ("ObjectiveComplete");
		objectiveCounter.incrementObjectives ();											// Increment the number of complete objectives
		targetHintText.enabled = false;														// Hide the ammo hint
		zombieHintText.enabled = true;														// Show the zombie hint
	}

	// Update is called once per frame
	IEnumerator ObjectiveComplete () {
		infoMsg.GetComponent<Text> ().text = "Objective 3:\nDestroy Targets Complete";		// Display objective complete message
		yield return new WaitForSeconds (2);												// Wait for the amount of time
		infoMsg.GetComponent<Text> ().text = "";											// Need to clear previous message or it writes over with camera change
		yield return new WaitForSeconds (0.5f);												// Wait for the amount of time to allow the text to be cleared
		infoMsg.GetComponent<Text> ().text = "Objective 4:\nFind and kill zombies";			// Then display the next objective
		StartCoroutine ("CameraViewport");													// Switch cameras
		yield return new WaitForSeconds (2);												// Wait for the amount of time
		infoMsg.GetComponent<Text> ().text = "";											// Then clear the message
	}

	IEnumerator CameraViewport () {
		ShowZombieLocation ();			 													// Show the zombie position camera in viewport
		yield return new WaitForSeconds (2);												// Wait for the amount of time
		ShowFPSCam();																		// Return to the FPS camera
	}

	private void ShowZombieLocation() {
		playerHUD.enabled = false;															// Hide the Player HUD canvas
		playerCam.enabled = false;															// Turn off the FPS camera
		zombieCam.enabled = true;															// Turn on the zombie position camera
	}

	private void ShowFPSCam(){
		playerHUD.enabled = true;															// Show the Player HUD canvas
		zombieCam.enabled = false;															// Turn off the zombie position camera
		playerCam.enabled = true;															// Turn on the FPS camera
	}
}
