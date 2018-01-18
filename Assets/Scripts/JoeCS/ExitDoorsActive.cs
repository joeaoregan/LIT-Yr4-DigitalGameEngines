using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorsActive : MonoBehaviour {

	public GameObject zombieObjective;				// 4th objective
	public GameObject exitSign;						// Exit text over door.
	public GameObject switchOn;						// Green button
	public GameObject swithcOff;					// Red button

	// Check has the zombie objective between complted
	void Update () {
		if (zombieObjective.activeInHierarchy) {
			gameObject.SetActive (true);			// Set the switch active
			exitSign.SetActive (true);				// Set the exit text active
			switchOn.SetActive (true);				// Set the on button active
			swithcOff.SetActive (false);			// Set the off button inactive
		}
	}
}
