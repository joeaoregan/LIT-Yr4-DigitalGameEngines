// Joe O'Regan
// Level 1
// Interact with the targets
// If the player has the gun show one message
// If the player has no gun, tell them get one

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetInteract : MonoBehaviour {

	public float distanceTo;															// Raycast distance to object

	private GameObject mainCam;															// Get the first person controller camera
	private Text infoMsg;																// Replaces actionText as information/action text in gam
	private GameObject gc;																// Game controller

	void Start () {
		gc = GameObject.FindWithTag ("GameController");									// Locate the game controller
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();			// Get the action/information text object
	}

	// Check raycast value
	void Update () {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();
	}

	private void OnMouseOver()
	{
		if (distanceTo <= 2.0f)
		{
			//if (gc.GetComponent<ObjectiveComplete> ().HasGun ()) {
			if (gc.GetComponent<ManageObjectives> ().GetObjective1Complete ()) {
				infoMsg.text = "Hit the bullseye\nWin a completed objective";
				StartCoroutine ("ClearText");
			} else {
				infoMsg.text = "Find the gun for target practice";
				StartCoroutine ("ClearText");
			}
		}
	}
	/*
	private void OnMouseExit()
	{
		infoMsg.text = "";
	}
	*/
	IEnumerator ClearText(){
		yield return new WaitForSeconds (2.0f);
		infoMsg.text = "";
	}

}
