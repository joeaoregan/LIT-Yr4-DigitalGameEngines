using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleInteractMessage : MonoBehaviour {

	public float distanceTo;
	public string Message1;
	public string Message2;

	private GameObject mainCam;
	private Text infoMsg;	// Replaces action text
	private bool dontOverWrite;

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
		if (distanceTo < 2.0f && !dontOverWrite) {
			int check = Random.Range (0, 10);
			if (check % 2 == 0) {
				infoMsg.text = Message1;
			} else {
				infoMsg.text = Message2;
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
