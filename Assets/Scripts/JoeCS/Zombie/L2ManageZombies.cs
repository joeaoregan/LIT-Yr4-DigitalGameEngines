using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	// Text

public class L2ManageZombies : MonoBehaviour {
	
	private int OBJECTIVE_TARGET = 10;	// zombies to kill level 2

	public int l2CurrentTargets;
	public int l2InternalTargets;
	public Text targetsText;	
	public Text actionText;

	public GameObject zombiesKilled;															// The game objective
	public ObjectiveCounter objectiveCounter;													// Number of completed objectives

	// Update is called once per frame
	void Update () {
		l2InternalTargets = l2CurrentTargets;

		targetsText.GetComponent<Text> ().text = "Zombies Killed: " + l2InternalTargets + "/10";

		if (l2CurrentTargets == OBJECTIVE_TARGET) {
			zombiesKilled.SetActive (true);													// Mark the kill zombies objective as completed
			StartCoroutine ("UpdateObjective"); 											// Display objective complete/next objective text
			objectiveCounter.incrementObjectives ();										// Increment the number of completed objectives
		}
	}

	public void incrementZombies(){
		if (l2CurrentTargets < OBJECTIVE_TARGET)
			l2CurrentTargets += 1;
		
	}

	IEnumerator UpdateObjective(){
		actionText.GetComponent<Text> ().text = "Objective 1:\nKill 10 Zombies Complete";
		yield return new WaitForSeconds (2);
		targetsText.GetComponent<Text> ().text = "";											// Reset the targets text message
		actionText.GetComponent<Text> ().text = "Objective 2:\nGet To The Lab";
		yield return new WaitForSeconds (2);
		actionText.GetComponent<Text> ().text = "";
	}
}
