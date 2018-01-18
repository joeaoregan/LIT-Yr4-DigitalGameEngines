// Joe O'Regan
// Level 3
// Objective 1 : Kill Zombies

// I was using objects actived/deactivated to communicate between JS and C# scripts up until I replaced most of the JS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L3Objective1KillZombies : MonoBehaviour {

	//public Text actionText;																		// Canvas action text
	//public ObjectiveCounter objectiveCounter;														// Number of objectives completed

	private Text infoMsg;																			// Replaces actionText, for displaying information messages
	private GameObject gc;																			// Game controller

	// Use this for initialization
	void Start () {
		gc = GameObject.FindWithTag ("GameController");												// Locate game controller
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();						// Locate the information text object
		//objectiveCounter.incrementObjectives ();													// Increment the number of complete objectives
		//if (!gc.GetComponent<ObjectiveComplete> ().ZombiesKilled())									// If the objective isn't already completed
		//	gc.GetComponent<ObjectiveComplete> ().SetZombiesKilled (true);							// Mark the objective as complete, and increment the number of completed objectives
		if (!gc.GetComponent<ManageObjectives> ().GetObjective1Complete())									// If the objective isn't already completed
			gc.GetComponent<ManageObjectives> ().SetObjective1Complete (true);							// Mark the objective as complete, and increment the number of completed objectives

		Debug.Log ("L3Objective1KillZombies: activated");

		StartCoroutine(ObjectiveComplete());
	}

	IEnumerator ObjectiveComplete () {
		//GameObject gc = GameObject.FindWithTag ("GameController");
		//gc.GetComponent<ObjectiveComplete> ().SetZombiesKilled (true);

		infoMsg.GetComponent<Text> ().text = "Objective 1:\nKill 10 Zombies Complete";				// Display objective complete message
		yield return new WaitForSeconds (2);														// Wait for the amount of time
		infoMsg.GetComponent<Text> ().text = "";													// Need to clear previous message or it writes over with camera change
		yield return new WaitForSeconds (0.5f);														// Wait for the amount of time to allow the text to be cleared
		infoMsg.GetComponent<Text> ().text = "Objective 2:\nClose Doorways To Great Hall Complete";	// Then display the next objective
		yield return new WaitForSeconds (2);														// Wait for the amount of time
		infoMsg.GetComponent<Text> ().text = "";													// Then clear the message
	}
}
