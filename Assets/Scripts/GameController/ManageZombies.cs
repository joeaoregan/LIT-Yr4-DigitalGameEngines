// Joe O'Regan
// Manage zombie kills and headshots

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;	// Text

public class ManageZombies : MonoBehaviour {

	//public Text headshotText;
	public int currentTargets;
	public int InternalTargets;
	public Text targetsText;	
	//public Text actionText;
	public GameObject zombiesKilled;																		// The game objective
	//public ObjectiveCounter objectiveCounter;																// Number of completed objectives

	private int OBJECTIVE_TARGET;
	private int zombieCount;
	//private Text infoMsg;
	private Animation anim;
	private int headshotCount;

	private bool pauseZombies;																				// Stop zombie movement for cutaways/end of level animations etc

	public bool ZombiesPaused() {																			// Are The zombies paused or not
		return pauseZombies;
	}

	public void PauseZombies(bool set){																		// Set the zombies paused/unpaused
		pauseZombies = set;
	}

	void Start(){
		pauseZombies = false;																				// Zombies initialised to move
		anim = targetsText.gameObject.GetComponent<Animation>();											// Initialise the animation
		//infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();							// Find the information/action text object

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
		headshotCount = PlayerPrefs.GetInt ("HeadshotCount");
	}

	// Update is called once per frame
	void Update () {
		InternalTargets = currentTargets;

		//if (currentTargets < OBJECTIVE_TARGET)
		if((GetComponent<ManageObjectives>().getObjectiveCount() == 3 && SceneManager.GetActiveScene().buildIndex == 3) || SceneManager.GetActiveScene().buildIndex >= 4) {	// If L1 objective met, or the level is level 2 or higher
			targetsText.GetComponent<Text> ().text = "Zombies Killed: " + InternalTargets + "/" + OBJECTIVE_TARGET;

			if (currentTargets >= OBJECTIVE_TARGET) {
				zombiesKilled.SetActive (true);																// Mark the kill zombies objective as completed
				Debug.Log("<color=red>Manage Zombies:</color> Zombie Objective Complete");
			}
		}
	}

	public void incrementZombies() {
		if (currentTargets < OBJECTIVE_TARGET) {
			currentTargets += 1;	
			anim.Play("HUDCanvasPanelTargetsText");							// Animate the text
		}

		ZombieCount ();														// Increment total zombies killed
	}

	public void incrementZombieHeadshots() {
		if (currentTargets < OBJECTIVE_TARGET) {
			currentTargets += 1;		
			anim.Play("HUDCanvasPanelTargetsText");							// Animate the text
			//StartCoroutine (HeadShotMsg());
			HeadshotCount();												// Increment and store the number of headshots
		}

		ZombieCount ();														// Increment total zombies killed
	}
	/*
	// Replaced with animated headshot text
	IEnumerator HeadShotMsg() {
		//actionText.GetComponent<Text> ().text = "Headshot 50";			// Display headshot message
		//infoMsg.GetComponent<Text> ().text = "Headshot 50";				// Display headshot message
		//headshotText.text = "Headshot " + headshotCount;
		yield return new WaitForSeconds (2);								// Show on screen for specified time
		//actionText.GetComponent<Text> ().text = "";						// Then clear the message
		infoMsg.GetComponent<Text> ().text = "";							// Then clear the message
	}
	*/

	// Total zombie kills
	void ZombieCount(){		
		zombieCount += 1;
		PlayerPrefs.SetInt ("ZombieCount", zombieCount);
	}
	public int totalZombieKills(){
		return zombieCount;
	}

	// Total headshots
	void HeadshotCount(){		
		headshotCount += 1;
		PlayerPrefs.SetInt ("HeadshotCount", headshotCount);
	}
	public int totalHeadshots(){
		return headshotCount;
	}

}
