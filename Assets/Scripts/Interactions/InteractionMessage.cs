// Joe O'Regan
// All Levels
// Single object interaction message
// Replaces many scripts on many objects

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionMessage : MonoBehaviour {
	
	public float distanceTo;
	public string displayMessage;

	private GameObject mainCam;
	private Text infoMsg;														// Replaces actionText

	//private GameObject gc;
	bool busy;

	void Start () {
		//gc = GameObject.FindWithTag ("GameController");
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();	// Find the information message object
		busy = false;															// No message sent yet
	}

	// Raycast
	void Update() {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();
	}

	void OnMouseOver() {
		if (distanceTo < 2.0f && !busy) {
			busy = true;
			StartCoroutine ("DisplayText");
		}
	}

	IEnumerator DisplayText(){
		infoMsg.text = displayMessage;
		yield return new WaitForSeconds (2);
		infoMsg.text = "";

		busy = false;
	}








}
