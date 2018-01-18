// Joe O'Regan
// Level 1
// Objective 3: Kill Zombies

// Stuff that happens after zombies are killed
// Set up Objective 4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieObjective : MonoBehaviour {

	//public Text actionText;															// Canvas action text
	//public ObjectiveCounter objectiveCounter;											// Number of objectives completed

	public Camera doorCam;																// Camera positioned overlooking doorway to Underground lab (Level 2)
	public Camera playerCam;															// FPS camera
	public GameObject doorSwitch;														// Activate the door trigger

	public Canvas playerHUD;															// Turn on/off player HUD when switching camera views

	public Text zombieHintText;
	public Text doorHintText;

	private Text infoMsg;																// Replaces actionText
	private GameObject gc;																// Game controller

	// Use this for initialization
	void Start () {
		gc = GameObject.FindWithTag ("GameController");									// Locate the game controller
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();			// Find the information message object
		StartCoroutine ("ObjectiveComplete");
		//objectiveCounter.incrementObjectives ();										// Increment the number of complete objectives
		gc.GetComponent<ManageObjectives>().SetObjective3Complete (true);				// Mark objective as complete, and Increment completed objectives
		doorSwitch.SetActive(true);														// Activate door trigger
		zombieHintText.enabled = false;
		doorHintText.enabled = true;
	}
	
	// Update is called once per frame
	IEnumerator ObjectiveComplete () {
		infoMsg.GetComponent<Text> ().text = "Objective 4:\nKill 3 Zombies Complete";	// Display objective complete message
		yield return new WaitForSeconds (2);											// Wait for the amount of time
		infoMsg.GetComponent<Text> ().text = "";										// Need to clear previous message or it writes over with camera change
		yield return new WaitForSeconds (0.5f);											// Wait for the amount of time to allow the text to be cleared
		infoMsg.GetComponent<Text> ().text = "Objective 5:\nFind The Lab Door";			// Then display the next objective
		StartCoroutine ("CameraViewport");												// Switch cameras
		yield return new WaitForSeconds (2);											// Wait for the amount of time
		infoMsg.GetComponent<Text> ().text = "";										// Then clear the message
	}

	IEnumerator CameraViewport () {
		ShowLabDoor ();			 														// Show the Lab Door camera in viewport
		yield return new WaitForSeconds (2);											// Wait for the amount of time
		ShowFPSCam();																	// Return to the FPS camera
	}

	private void ShowLabDoor() {
		playerHUD.enabled = false;														// Hide the Player HUD canvas
		playerCam.enabled = false;														// Turn off the FPS camera
		doorCam.enabled = true;															// Turn on the Lab Door camera
	}

	private void ShowFPSCam(){
		playerHUD.enabled = true;														// Show the Player HUD canvas
		doorCam.enabled = false;														// Turn off the Lab Door camera
		playerCam.enabled = true;														// Turn on the FPS camera
	}
}
