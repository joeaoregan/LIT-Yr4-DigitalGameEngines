using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoObjectivePickup : MonoBehaviour {

	public ObjectiveCounter objectivesCounter;								// Check the number of complete objective
	public GameObject getAmmoObjective;										// Mark the get ammo objective as complete

	void OnTriggerEnter (Collider Player) {

		if (objectivesCounter.getObjectiveCount () == 1) {					// If we are looking to complete the 2nd objective (pick up ammo)
			getAmmoObjective.SetActive (true);								// Mark the get ammo objective as complete
		}
	}
}
