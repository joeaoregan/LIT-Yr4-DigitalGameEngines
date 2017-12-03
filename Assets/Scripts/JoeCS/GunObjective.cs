using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunObjective : MonoBehaviour {

	public Text actionText;																// Canvas action text
	public ObjectiveCounter objectiveCounter;											// Amount of completed objectives

	// Use this for initialization
	void Start () {
		StartCoroutine ("ObjectiveComplete");
		objectiveCounter.incrementObjectives ();										// Increment the number of complete objectives
	}
	
	// Update is called once per frame
	IEnumerator ObjectiveComplete () {
		actionText.GetComponent<Text> ().text = "Objective 1:\nFind Gun Complete";		// Display message
		yield return new WaitForSeconds (2);											// Wait for the amount of time
		actionText.GetComponent<Text> ().text = "Objective 2:\nFind Ammo";				// Then clear the message
		yield return new WaitForSeconds (2);											// Wait for the amount of time
		actionText.GetComponent<Text> ().text = "";										// Then clear the message
	}
}
