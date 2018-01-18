using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveComplete : MonoBehaviour {

	// Mark objectives as completed instead of using objects enabled/disabled on objects

	// Level 1
	bool hasGun;					// Objective 1
	bool destroyTargets;			// Objective 3
	bool killZombies;				// Objective 4

	// Level 3
	bool zombieObjectiveComplete;	// Objective 1
	bool doorObjectiveComplete;		// Objective 2
	bool labObjectiveComplete;		// Objective 3
	bool findGirlObjectiveComplete;	// Objective 4

	// Use this for initialization
	void Start () {
		zombieObjectiveComplete = false;
		doorObjectiveComplete = false;
	}

	/* LEVEL 1 */
	// Objective 1: Get Gun
	public bool HasGun() {
		return hasGun;
	}
	public void SetHasGun(bool set){
		hasGun = set;
		GetComponent<ObjectiveCounter>().incrementObjectives ();
	}

	// Objective 3: Destroy the targets
	public bool TargetsDestroyed() {
		return destroyTargets;
	}
	public void SetTargetsDestroyed(bool set){
		destroyTargets = set;
		GetComponent<ObjectiveCounter>().incrementObjectives ();
	}

	// Objective 3: Kill 3 Zombies
	public bool GetObjective3() {
		return killZombies;
	}
	public void SetObjective3(bool set){
		killZombies = set;
		GetComponent<ObjectiveCounter>().incrementObjectives ();
	}



	/* LEVEL 2 */

	/* LEVEL 3 */

	// Objective 1: Kill zombies
	public bool ZombiesKilled() {
		Debug.Log("<color=blue>Objective Complete:</color> Zombie Objective Complete");
		return zombieObjectiveComplete;
	}

	public void SetZombiesKilled(bool set) {
		Debug.Log("<color=blue>Objective Complete:</color> Zombie Objective Marked As Complete");
		zombieObjectiveComplete = set;
		//if (set) 
		//Debug.Log ("ObjectiveCompleted: Increment Objectives");
		GetComponent<ObjectiveCounter>().incrementObjectives ();
	}

	// Objective 2: Open doors
	public bool doorsClosed() {
		return doorObjectiveComplete;
	}

	public void setDoorsClosed(bool set) {
		doorObjectiveComplete = set;
		GetComponent<ObjectiveCounter>().incrementObjectives ();
	}

	// Objective 3: Get to lab
	public bool GetToLab() {
		return labObjectiveComplete;
	}

	public void SetGetToLab(bool set){
		labObjectiveComplete = set;
		GetComponent<ObjectiveCounter>().incrementObjectives ();
	}

	// Objective 4: Find the girl
	public bool GirlFound() {
		return findGirlObjectiveComplete;
	}

	public void SetGirlFound(bool set) {
		findGirlObjectiveComplete = set;
		//GetComponent<ObjectiveCounter>().incrementObjectives ();
	}
}
