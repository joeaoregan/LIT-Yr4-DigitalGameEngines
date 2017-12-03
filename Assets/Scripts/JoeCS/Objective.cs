using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;		// Text object

public class Objective : MonoBehaviour {
	
	public Text actionText;														// Displays action message

	public Camera gunCam;														// Camera positioned by Gun
	public Camera playerCam;													// FPS camera

	void Start () {
		StartCoroutine ("FirstObjective");
		//FirstObjective();
	}

	// Update is called once per frame
	IEnumerator FirstObjective () {
	//private void FirstObjective() {
		actionText.GetComponent<Text> ().text = "Objective 1:\nFind A Gun";		// Display message
		yield return new WaitForSeconds (0.5f);									// Wait for the amount of time
		StartCoroutine ("CameraViewport");										// Switch cameras
		yield return new WaitForSeconds (2);									// Wait for the amount of time (Coroutine time delay is separate)
		actionText.GetComponent<Text> ().text = "";								// Then clear the message
	}

	IEnumerator CameraViewport () {
		actionText.GetComponent<Text> ().text = "Objective 1:\nFind A Gun";		// Display message
		showGun ();			 													// Show the gun camera in viewport
		yield return new WaitForSeconds (2);									// Wait for the amount of time
		ShowFPSCam ();															// Return to the FPS camera
	}

	private void showGun() {
		playerCam.enabled = false;												// Turn off the FPS camera
		gunCam.enabled = true;													// Turn on the gun camera
	}

	private void ShowFPSCam(){
		gunCam.enabled = false;													// Turn off the gun camera
		playerCam.enabled = true;												// Turn on the FPS camera
	}
}
