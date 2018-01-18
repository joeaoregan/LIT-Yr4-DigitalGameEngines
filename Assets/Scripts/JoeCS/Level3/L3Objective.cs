using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;		// Text object

public class L3Objective : MonoBehaviour {
	
	//public Text actionText;													// Displays action message
	private Text infoMsg;														// Replaces actionText, for displaying information messages

	void Start () {
		StartCoroutine ("FirstObjective");
	}

	IEnumerator FirstObjective () {
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();	// Locate the information text object
		infoMsg.GetComponent<Text> ().text = "Objective 1:\nKill 10 Zombies";	// Display message
		yield return new WaitForSeconds (2);									// Wait for the amount of time (Coroutine time delay is separate)
		infoMsg.GetComponent<Text> ().text = "";								// Then clear the message
	}
}
