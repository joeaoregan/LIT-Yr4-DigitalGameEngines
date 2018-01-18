using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveComplete : MonoBehaviour {

	// Mark objectives as completed instead of using objects enabled/disabled
	bool zombieObjectiveComplete;	// Objective 1
	bool doorObjectiveComplete;		// Objective 2
	bool labObjectiveComplete;		// Objective 3
	bool findGirlObjectiveComplete;	// Objective 4

	// Use this for initialization
	void Start () {
		zombieObjectiveComplete = false;
		doorObjectiveComplete = false;
	}

	// Objective 1: Kill zombies
	public bool ZombiesKilled() {

		Debug.Log("<color=blue>Objective Complete:</color> Zombie Objective Complete");
		return zombieObjectiveComplete;
	}

	public void SetZombiesKilled(bool set) {
		zombieObjectiveComplete = set;
	}

	// Objective 2: Open doors
	public bool doorsClosed() {
		return doorObjectiveComplete;
	}

	public void setDoorsClosed(bool set) {
		doorObjectiveComplete = set;
	}

	// Objective 3: Get to lab
	public bool GetToLab() {
		return labObjectiveComplete;
	}

	public void SetGetToLab(bool set){
		labObjectiveComplete = set;
	}

	// Objective 4: Find the girl
	public bool GirlFound() {
		return findGirlObjectiveComplete;
	}

	public void SetGirlFound(bool set) {
		findGirlObjectiveComplete = set;
	}
}
