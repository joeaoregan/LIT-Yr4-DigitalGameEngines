// Joe O'Regan
// Level 1
// Objective 2: Pick up ammo for the gun
// Player can't pick up ammo until they have first collected the gun

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoObjectivePickup : MonoBehaviour {

	//public ObjectiveCounter objectivesCounter;							// Check the number of complete objective
	public GameObject getAmmoObjective;										// Mark the get ammo objective as complete

	private GameObject gc;													// Game controller

	void Start(){
		gc = GameObject.FindWithTag ("GameController");						// Locate the game controller
	}

	void OnTriggerEnter (Collider Player) {

		//if (objectivesCounter.getObjectiveCount () == 1) {				// If we are looking to complete the 2nd objective (pick up ammo)
		if (gc.GetComponent<ObjectiveCounter>().getObjectiveCount () == 1) {// If we are looking to complete the 2nd objective (pick up ammo)
			getAmmoObjective.SetActive (true);								// Mark the get ammo objective as complete
		}
	}
}
