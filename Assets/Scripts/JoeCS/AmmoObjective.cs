using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoObjective : MonoBehaviour {

	public Text actionText;																		// Canvas action text
	public ObjectiveCounter objectiveCounter;

	// Use this for initialization
	void Start () {
		StartCoroutine ("ObjectiveComplete");
		objectiveCounter.incrementObjectives ();												// Increment the number of complete objectives
	}
	
	// Update is called once per frame
	IEnumerator ObjectiveComplete () {
		actionText.GetComponent<Text> ().text = "Objective 2:\nFind Ammo For Gun Complete";		// Display objective complete message
		yield return new WaitForSeconds (2);													// Wait for the amount of time
		actionText.GetComponent<Text> ().text = "Objective 3:\nDestroy 4 Shooting Range Targets";// Then display the next objective
		yield return new WaitForSeconds (2);													// Wait for the amount of time
		actionText.GetComponent<Text> ().text = "";												// Then clear the message
	}
}
