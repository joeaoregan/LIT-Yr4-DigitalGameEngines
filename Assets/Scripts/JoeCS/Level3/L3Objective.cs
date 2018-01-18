using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;		// Text object

public class L3Objective : MonoBehaviour {
	
	public Text actionText;														// Displays action message

	void Start () {
		StartCoroutine ("FirstObjective");
	}

	IEnumerator FirstObjective () {
		actionText.GetComponent<Text> ().text = "Objective 1:\nKill 10 Zombies";// Display message
		yield return new WaitForSeconds (2);									// Wait for the amount of time (Coroutine time delay is separate)
		actionText.GetComponent<Text> ().text = "";								// Then clear the message
	}
}
