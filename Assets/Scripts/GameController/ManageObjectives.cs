// Joe O'Regan
// All Levels (Game Controller Component)
// Mark Objectives As Complete When Done

// Manage the number of objectives completed
// Mark complted as true, and increment the number of completed objectives

// Mark objectives as completed instead of using objects enabled/disabled on objects

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageObjectives : MonoBehaviour {

	public Text objectiveText;											// Objective text on HUD panel
	public int completedObjectives;										// number of completed objectives

	private Animation anim;												// Animate the objective text when incremented
	private bool objective1;
	private bool objective2;
	private bool objective3;
	private bool objective4;

	void Start () {
		anim = objectiveText.gameObject.GetComponent<Animation>();		// Initialise the animation

		ResetObjectives();												// Initialise the values of variables
		UpdateObjectiveText ();
	}

	void Update () {
		UpdateObjectiveText ();
	}

	public bool GetObjective1Complete() { return objective1; }			// Level 1: Get Gun - Level 2 & 3: Kill Zombies
	public bool GetObjective2Complete() { return objective2; }			// Level 1: Pick up ammo - Level 3: Close hall doors
	public bool GetObjective3Complete() { return objective3; }			// Level 1: Targets Destroyed - Level 3: Get To The Lab 
	public bool GetObjective4Complete() { return objective4; }			// Level 3: Find girl

	// Level 1: Get Gun - Level 2 & 3: Kill Zombies
	public void SetObjective1Complete(bool set){
		objective1 = set;
		incrementObjectives ();
	}

	// Level 1: Pick up ammo - Level 3: Close hall doors
	public void SetObjective2Complete(bool set){
		objective2 = set;
		incrementObjectives ();
	}

	// Level 1: Targets Destroyed - Level 3: Get To The Lab 
	public void SetObjective3Complete(bool set){
		objective3 = set;
		incrementObjectives ();
	}

	// Level 3: Find girl
	public void SetObjective4Complete(bool set){
		objective4 = set;
		incrementObjectives ();
	}

	public void ResetObjectives(){
		completedObjectives = 0;
		objective1 = false;
		objective2 = false;
		objective3 = false;
		objective4 = false;
	}

	void UpdateObjectiveText() {
		if (SceneManager.GetActiveScene().buildIndex == 3)
			objectiveText.GetComponent<Text> ().text = "Objectives: " + completedObjectives + "/5";
		if (SceneManager.GetActiveScene().buildIndex == 4)
			objectiveText.GetComponent<Text> ().text = "Objectives: " + completedObjectives + "/2";
		if (SceneManager.GetActiveScene().buildIndex == 5)
			objectiveText.GetComponent<Text> ().text = "Objectives: " + completedObjectives + "/4";
	}

	public void incrementObjectives(){
		//Debug.Log ("IncrementObjectives: Increment Objectives");
		completedObjectives++;
		anim.Play("HUDCanvasPanelTargetsText");														// Animate the text
	}

	public int getObjectiveCount() {
		return completedObjectives;
	}
}
