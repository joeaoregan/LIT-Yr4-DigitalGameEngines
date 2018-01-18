// Joe O'Regan
// Level 1
// Interact with fake gun
// play sounds and give messages

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BondGunInteract: MonoBehaviour {

	public float distanceTo;															// Raycast distance to object

	private GameObject mainCam;															// Get the first person controller camera
	private Text infoMsg;																// Replaces actionText as information/action text in gam
	private GameObject gc;																// Game controller
	AudioSource bondGunAudio;															// Get the audio source

	void Start () {
		gc = GameObject.FindWithTag ("GameController");									// Locate the game controller
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();			// Get the action/information text object
		bondGunAudio = GetComponent<AudioSource>();
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
				infoMsg.text = "You Have A Gun\nThis Is Ornamental";
				StartCoroutine ("ClearText");
			} else {
				infoMsg.text = "Seems A Bit Too James Bond\nMust Be Other Guns On Other Racks";

				StartCoroutine ("ClearText");
			}

			if (Input.GetButtonDown("Action"))
				BondAudio ();															// Play the bond theme audio
		}
	}

	private void OnMouseExit()
	{
		if (distanceTo <= 2.0f) {
			//if (!gc.GetComponent<ObjectiveComplete> ().HasGun ()) {
			if (!gc.GetComponent<ManageObjectives> ().GetObjective1Complete ()) {
				infoMsg.text = "Jedi Mind Trick:\nThis is not the gun you are looking for";
				StartCoroutine ("ClearText");
			}
		}
	}

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2.0f);
		infoMsg.text = "";
	}

	void BondAudio() {
		bondGunAudio.Play();    																	  				// Display a message 
	}
}
