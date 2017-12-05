using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	// Text

public class ManageZombies : MonoBehaviour {


	private int OBJECTIVE_TARGET = 3;

	public int currentTargets;
	public int InternalTargets;
	public Text targetsText;	
	public Text actionText;

	public GameObject zombiesKilled;															// The game objective
	public ObjectiveCounter objectiveCounter;													// Number of completed objectives

	// Update is called once per frame
	void Update () {
		InternalTargets = currentTargets;

		//if (currentTargets < OBJECTIVE_TARGET)
		if(objectiveCounter.getObjectiveCount() == 3) {
			targetsText.GetComponent<Text> ().text = "Zombies Killed: " + InternalTargets + "/3";

			if (currentTargets == OBJECTIVE_TARGET) {
				zombiesKilled.SetActive (true);													// Mark the kill zombies objective as completed
				//StartCoroutine ("UpdateObjective");
				//objectiveCounter.incrementObjectives ();										// Increment the number of completed objectives
			}
		}
	}

	public void incrementZombies(){
		if (currentTargets < OBJECTIVE_TARGET)
			currentTargets += 1;
		
	}

	IEnumerator UpdateObjective(){
		actionText.GetComponent<Text> ().text = "Objective 4:\nKill 3 Zombies Complete";
		yield return new WaitForSeconds (2);
		targetsText.GetComponent<Text> ().text = "";											// Reset the targets text message
		actionText.GetComponent<Text> ().text = "Objective 5:\nFind The Lab Door";
		yield return new WaitForSeconds (2);
		actionText.GetComponent<Text> ().text = "";
	}
}
