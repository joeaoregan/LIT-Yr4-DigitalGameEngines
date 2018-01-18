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

public class L1InteractCCTV : MonoBehaviour {

	GameObject mainCam;
	public float distanceTo;

	public Text actionText;

	// Use this for initialization
	void Start () {
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	void Update() {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();


		//if (distanceTo < 2.0f) {
		//	actionText.text = "Looks like some of the outside cameras have been disabled";
		//	StartCoroutine ("ClearText");
		//}
	}
	
	void OnMouseOver() {
		Debug.Log ("Mouse over CCTV");

		if (distanceTo < 2.0f) {
			actionText.text = "Looks like some of the outside cameras have been disabled";
			StartCoroutine ("ClearText");
		}
	}

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2);
		actionText.text = "";
	}
}
