using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointDoorClose: MonoBehaviour {

	//public GameObject ZombieObjective;
	public GameObject switchOn;						// Green button
	public GameObject swithcOff;					// Red button

	// Check has the zombie objective between complted
	void Update () {
		// ObjectiveComplete is a script component of the Game Controller
		if (GameObject.FindWithTag("GameController").GetComponent<ObjectiveComplete>().ZombiesKilled()) {
			switchOn.SetActive (true);				// Set the on button active
			swithcOff.SetActive (false);			// Set the off button inactive
		}
	}
}
