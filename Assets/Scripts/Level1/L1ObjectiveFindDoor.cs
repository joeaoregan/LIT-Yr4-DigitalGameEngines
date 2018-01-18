using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1ObjectiveFindDoor : MonoBehaviour {

	public Animator fadeToNextLevel;
	public Canvas playerHUD;

	GameObject player;
	GameObject gc;												// Game Controller

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");  	// Locate the Player
		gc = GameObject.FindWithTag ("GameController");	   		// Locate the Game Controller
	}


	/*
	 * When the player enters the doorway trigger
	 * Load level 2
	*/
	void OnTriggerEnter(Collider other){                        // Called whenever anything goes into a trigger
		if (other.gameObject == player) {                       // Make sure it is the player we are attacking
			//gc.GetComponent<ExitLevel1> ().SaveState ();
			//gc.GetComponent<ExitLevel> ().ProgressLevels ();
			gc.GetComponent<ExitLevel> ().SaveState ();
			playerHUD.enabled = false;
			fadeToNextLevel.SetTrigger ("Fade");
		}
	}
}
