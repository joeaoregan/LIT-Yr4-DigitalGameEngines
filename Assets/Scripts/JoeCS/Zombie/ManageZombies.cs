using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;	// Text

public class ManageZombies : MonoBehaviour {
	
	public int currentTargets;
	public int InternalTargets;
	public Text targetsText;	
	public Text actionText;

	public GameObject zombiesKilled;																		// The game objective
	public ObjectiveCounter objectiveCounter;																// Number of completed objectives

	private int OBJECTIVE_TARGET;

	int zombieCount;

	void Start(){
		if (SceneManager.GetActiveScene ().buildIndex == 3) {
			OBJECTIVE_TARGET = 3;																			// Level 1
			Debug.Log("Level 1: Kill 3 Zombies");
			PlayerPrefs.SetInt ("ZombieCount", 0);															// Reset the zombie count for level 1
		}
		else if (SceneManager.GetActiveScene ().buildIndex == 4) {
			OBJECTIVE_TARGET = 5;																			// Level 2
			Debug.Log("Level 2: Kill 5 Zombies");
		}
		else {
			OBJECTIVE_TARGET = 10;																			// Level 3	
			Debug.Log("Level 3: Kill 10 Zombies");	
		}

		zombieCount = PlayerPrefs.GetInt ("ZombieCount");
	}

	// Update is called once per frame
	void Update () {
		InternalTargets = currentTargets;

		//if (currentTargets < OBJECTIVE_TARGET)
		if(objectiveCounter.getObjectiveCount() == 3 || SceneManager.GetActiveScene().buildIndex >= 4) {	// If L1 objective met, or the level is level 2 or higher
			targetsText.GetComponent<Text> ().text = "Zombies Killed: " + InternalTargets + "/" + OBJECTIVE_TARGET;

			if (currentTargets == OBJECTIVE_TARGET) {
				zombiesKilled.SetActive (true);																// Mark the kill zombies objective as completed
			}
		}
	}

	public void incrementZombies() {
		if (currentTargets < OBJECTIVE_TARGET)
			currentTargets += 1;	
		
		ZombieCount ();														// Increment total zombies killed
	}

	public void incrementZombieHeadshots() {
		if (currentTargets < OBJECTIVE_TARGET) {
			currentTargets += 1;		
			StartCoroutine (HeadShotMsg());
		}

		ZombieCount ();														// Increment total zombies killed
	}

	IEnumerator HeadShotMsg() {
		actionText.GetComponent<Text> ().text = "Headshot 50";				// Display headshot message
		yield return new WaitForSeconds (2);								// Show on screen for specified time
		actionText.GetComponent<Text> ().text = "";							// Then clear the message
	}

	void ZombieCount(){		
		zombieCount += 1;
		PlayerPrefs.SetInt ("ZombieCount", zombieCount);
	}

	public int totalZombieKills(){
		return zombieCount;
	}
}
