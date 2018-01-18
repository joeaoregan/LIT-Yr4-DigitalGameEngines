// Joe O'Regan
// Level 3
// If the zombie objective is complete, turn door switch on (green)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointDoorClose: MonoBehaviour {

	//public GameObject ZombieObjective;
	public GameObject switchOn;						// Green button
	public GameObject switchOff;					// Red button

	// Check has the zombie objective between complted
	void Update () {
		// ObjectiveComplete is a script component of the Game Controller
		//if (GameObject.FindWithTag("GameController").GetComponent<ObjectiveComplete>().ZombiesKilled()) {
		if (GameObject.FindWithTag("GameController").GetComponent<ManageObjectives>().GetObjective1Complete()) {
			switchOn.SetActive (true);				// Set the on button active
			switchOff.SetActive (false);			// Set the off button inactive
		}
	}
}
