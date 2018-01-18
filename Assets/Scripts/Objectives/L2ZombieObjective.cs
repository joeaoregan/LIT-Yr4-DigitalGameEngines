// Joe O'Regan
// Level 2
// Objective 1: Kill Zombies


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L2ZombieObjective : MonoBehaviour {

	//public Text actionText;																// Canvas action text
	//public ObjectiveCounter objectiveCounter;												// Number of objectives completed

	//public Camera doorCam;																// Camera positioned overlooking doorway to Underground lab (Level 2)
	//public Camera playerCam;																// FPS camera
	//public GameObject doorSwitch;															// Activate the door trigger

	private Text infoMsg;																	// Replaces actionText, for displaying information messages
	private GameObject gc;

	// Use this for initialization
	void Start () {
		gc = GameObject.FindWithTag ("GameController");										// Locate game controller
		gc.GetComponent<ManageObjectives>().incrementObjectives ();							// Increment the number of complete objectives
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();				// Locate the information text object
		StartCoroutine ("ObjectiveComplete");

		//objectiveCounter.incrementObjectives ();											// Increment the number of complete objectives
		//doorSwitch.SetActive(true);														// Activate door trigger
	}
	
	// Update is called once per frame
	IEnumerator ObjectiveComplete () {

		infoMsg.GetComponent<Text> ().text = "Objective 1:\nKill 5 Zombies Complete";		// Display objective complete message
		yield return new WaitForSeconds (2);												// Wait for the amount of time
		infoMsg.GetComponent<Text> ().text = "";											// Need to clear previous message or it writes over with camera change
		yield return new WaitForSeconds (0.5f);												// Wait for the amount of time to allow the text to be cleared
		infoMsg.GetComponent<Text> ().text = "Objective 2:\nGet To The Lab";				// Then display the next objective
		//StartCoroutine ("CameraViewport");												// Switch cameras
		yield return new WaitForSeconds (2);												// Wait for the amount of time
		infoMsg.GetComponent<Text> ().text = "";											// Then clear the message
	}
	/*
	IEnumerator CameraViewport () {
		ShowLabDoor ();			 															// Show the Lab Door camera in viewport
		yield return new WaitForSeconds (2);												// Wait for the amount of time
		ShowFPSCam();																		// Return to the FPS camera
	}

	private void ShowLabDoor() {
		playerCam.enabled = false;															// Turn off the FPS camera
		doorCam.enabled = true;																// Turn on the Lab Door camera
	}

	private void ShowFPSCam(){
		doorCam.enabled = false;															// Turn off the Lab Door camera
		playerCam.enabled = true;															// Turn on the FPS camera
	}
	*/
}
