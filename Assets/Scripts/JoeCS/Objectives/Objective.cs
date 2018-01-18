using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;		// Text object

public class Objective : MonoBehaviour {
	
	public Text actionText;														// Displays action message

	public Camera gunCam;														// Camera positioned by Gun
	public Camera playerCam;													// FPS camera

	public Canvas playerHUD;

	// CCTV Screen hints
	public Text ammoHintText;													// Hint at ammo location on CCTV screen
	public Text zombieHintText;													// Hint at Zombie location on CCTV scren
	public Text doorHintText;													// Hint at lab door location on CCTV screen

	void Start () {
		StartCoroutine ("FirstObjective");
		//FirstObjective();
		ammoHintText.enabled = false;											// Disable hint until preceeding objective complete
		zombieHintText.enabled = false;
		doorHintText.enabled = false;
	}

	// Update is called once per frame
	IEnumerator FirstObjective () {
	//private void FirstObjective() {
		//actionText.GetComponent<Text> ().text = "Objective 1:\nFind A Gun";	// Display message
		yield return new WaitForSeconds (0.5f);									// Wait for the amount of time
		StartCoroutine ("CameraViewport");										// Switch cameras
		//yield return new WaitForSeconds (2);									// Wait for the amount of time (Coroutine time delay is separate)
		//actionText.GetComponent<Text> ().text = "";								// Then clear the message
	}

	IEnumerator CameraViewport () {
		//actionText.GetComponent<Text> ().text = "Objective 1:\nFind A Gun";	// Display message
		showGun ();			 													// Show the gun camera in viewport
		yield return new WaitForSeconds (2);									// Wait for the amount of time
		ShowFPSCam ();															// Return to the FPS camera
	}

	private void showGun() {
		playerHUD.enabled = false;												// Hide the Player HUD canvas
		playerCam.enabled = false;												// Turn off the FPS camera
		gunCam.enabled = true;													// Turn on the gun camera
	}

	private void ShowFPSCam(){
		playerHUD.enabled = true;												// Show the Player HUD canvas
		gunCam.enabled = false;													// Turn off the gun camera
		playerCam.enabled = true;												// Turn on the FPS camera
	}
}
