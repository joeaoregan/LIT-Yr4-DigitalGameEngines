using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionMessage : MonoBehaviour {

	public float distanceTo;
	public string displayMessage;

	private GameObject mainCam;
	private Text infoMsg;														// Replaces actionText

	void Start () {
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();	// Find the information message object
	}

	// Raycast
	void Update() {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();
	}

	void OnMouseOver() {
		if (distanceTo < 2.0f) {
			infoMsg.text = displayMessage;
			StartCoroutine ("ClearText");
		}
	}

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2);
		infoMsg.text = "";
	}
}
