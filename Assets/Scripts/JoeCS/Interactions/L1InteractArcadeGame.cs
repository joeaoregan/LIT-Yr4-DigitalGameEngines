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

public class L1InteractArcadeGame: MonoBehaviour {

	GameObject mainCam;
	public float distanceTo;

	public Text actionText;

	// Use this for initialization
	void Start () {
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	void Update() {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();
	}
	
	void OnMouseOver() {
		Debug.Log ("Mouse over Arcade Game");

		if (distanceTo < 2.0f) {
			actionText.text = "Insert coin?";
			StartCoroutine ("ClearText");
		}
	}

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2);
		actionText.text = "";
	}
}
