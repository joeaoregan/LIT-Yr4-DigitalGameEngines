/*
 * Joe O'Regan
 * K00203642
 * 
 * Convert JavaScript interaction scripts to C#
 * 
 * Make sure and attach collider for mouse over to work
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L1InteractPosterMessage : MonoBehaviour {
	
	public float distanceTo;

	Text infoMsg;
	GameObject mainCam;

	// Use this for initialization
	void Start () {
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();
	}

	void Update() {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();
	}
	
	void OnMouseOver() {
		Debug.Log ("Mouse over Message Poster");

		if (distanceTo < 2.0f) {
			infoMsg.text = "Looks like it's written in blood";
			StartCoroutine ("ClearText");
		}
	}

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2);
		infoMsg.text = "";
	}
}
