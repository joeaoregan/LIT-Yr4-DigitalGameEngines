using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L3Objective1KillZombies : MonoBehaviour {

	public Text actionText;																				// Canvas action text
	public ObjectiveCounter objectiveCounter;															// Number of objectives completed

	// Use this for initialization
	void Start () {
		StartCoroutine ("ObjectiveComplete");
		objectiveCounter.incrementObjectives ();														// Increment the number of complete objectives
	}
	
	// Update is called once per frame
	IEnumerator ObjectiveComplete () {
		GameObject gc = GameObject.FindWithTag ("GameController");
		gc.GetComponent<ObjectiveComplete> ().SetZombiesKilled (true);

		actionText.GetComponent<Text> ().text = "Objective 1:\nKill 10 Zombies Complete";				// Display objective complete message
		yield return new WaitForSeconds (2);															// Wait for the amount of time
		actionText.GetComponent<Text> ().text = "";														// Need to clear previous message or it writes over with camera change
		yield return new WaitForSeconds (0.5f);															// Wait for the amount of time to allow the text to be cleared
		actionText.GetComponent<Text> ().text = "Objective 2:\nClose Doorways To Great Hall Complete";	// Then display the next objective
		yield return new WaitForSeconds (2);															// Wait for the amount of time
		actionText.GetComponent<Text> ().text = "";														// Then clear the message
	}
}
