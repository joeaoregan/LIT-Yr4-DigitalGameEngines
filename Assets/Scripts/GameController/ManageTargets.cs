/*
 * ManageTargets.cs
 * 
 * Joe O'Regan
 * 03/12/2017
 * 
 * Manage the targets and play animation when the targets increment
 * animating the text that displays the number of targets/zombies shot
 * 
 * The increment targets function is called when the player shoots a target
 * or a zombie, and helps keep track of the number required for objectives
 */ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageTargets : MonoBehaviour {

    public int currentTargets;
    public int InternalTargets;
	public Text targetsText;															// Targets text on HUD panel

	public GameObject targetsDestroyed;													// Number of targets shot

	//public ObjectiveCounter objectiveCounter;											// Amount of completed objectives 

	private int MAX_TARGETS = 4;

	//private Text infoMsg;

	private Animation anim;

	private GameObject gc;																// Game controller

	void Start () {
		gc = GameObject.FindWithTag ("GameController");									// Locate the game controller
		anim = targetsText.gameObject.GetComponent<Animation>();						// Initialise the animation
		//infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		InternalTargets = currentTargets;

		//if (currentTargets < MAX_TARGETS && gc.GetComponent<ObjectiveComplete>().HasGun())
		if (currentTargets < MAX_TARGETS && gc.GetComponent<ManageObjectives>().GetObjective1Complete())
			targetsText.GetComponent<Text> ().text = "Targets: " + InternalTargets + "/4";

		//if (currentTargets == MAX_TARGETS && objectiveCounter.getObjectiveCount() == 2) {
		if (currentTargets == MAX_TARGETS && gc.GetComponent<ManageObjectives>().getObjectiveCount() == 2) {
			
			targetsDestroyed.SetActive (true);
			//StartCoroutine ("UpdateObjective");
			//if (objectiveCounter.getObjectiveCount() == 2)							// If 2 objectives have been complete
			//	objectiveCounter.incrementObjectives ();								// Increment the number of completed objectives
		}
    }

	/*
	 	Increment the number of targets destroyed
		public function to be called from within other scripts
	*/
	public void IncrementTargets() {
		if (currentTargets < MAX_TARGETS)
			currentTargets += 1;														// Add 1 to the number of destroyed targets
		anim.Play("HUDCanvasPanelTargetsText");											// Animate the text
	}
	/*
	IEnumerator UpdateObjective(){
		//yield return new WaitForSeconds (1);											// Wait 1 second
		targetsText.GetComponent<Text> ().text = "";									// Reset the targets text message
		infoMsg.GetComponent<Text> ().text = "Objective 3:\nDestroy Targets Complete";
		yield return new WaitForSeconds (2);
		infoMsg.GetComponent<Text> ().text = "Objective 4:\nFind and kill zombies";
		yield return new WaitForSeconds (2);
		infoMsg.GetComponent<Text> ().text = "";										// Reset the action text
		//targetsText.GetComponent<Text> ().text = "Zombies Killed: 0/3";				// Change the targets text to the Zombie Kill count
	}
	*/
}
