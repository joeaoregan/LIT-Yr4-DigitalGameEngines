using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleInteract : MonoBehaviour {

	public float distanceTo;

	GameObject mainCam;
	Text infoMsg;
	bool dontOverWrite;

	void Start () {
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();
		dontOverWrite = false;
	}

	// Raycast
	void Update () {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();
	}

	void OnMouseOver() {
		Debug.Log ("Mouse over CCTV");

		if (distanceTo < 2.0f && !dontOverWrite) {
			int check = Random.Range (0, 10);
			if (check % 2 == 0) {
				infoMsg.text = "I could use this for target practice";
			} else {
				infoMsg.text = "Gets from A to B, if B is right there";
			}

			StartCoroutine ("ClearText");
		}

		dontOverWrite = true;
	}

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2.0f);
		infoMsg.text = "";
		dontOverWrite = false;
	}

	void OnMouseExit(){
		dontOverWrite = false;
	}
}
