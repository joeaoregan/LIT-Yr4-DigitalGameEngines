// Joe O'Regan
// Level 1
// Specific interaction with the door
// It started to get annoying that the same objects were interacted with
// Instead of doing it once and turning it off
// I made it choose from random phrases, then stop when an objective is complete

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class L1DormDoorInteract : MonoBehaviour {

	public float distanceTo;													// Raycast distance to object
	public string[] phrases;													// List of phrases entered in editor

	private int phraseSelect;													// Phrase to randomly select from phrases list
	private GameObject mainCam;													// Main camera on player fps controller
	private Text infoMsg;														// Replaces actionText
	private GameObject gc;														// Game Controller

	void Start () {
		gc = GameObject.FindWithTag ("GameController");							// Locate the game controller
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");				// Locate the main camera
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();	// Find the information message object
		phraseSelect = 0;
	}

	// Raycast
	void Update() {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();
	}

	void OnMouseOver() {
		if (distanceTo < 2.0f) {
			if (phraseSelect == 0)												// Won't repeat, only set at end of InfoMessage function
				StartCoroutine (InfoMessage());
		}
	}

	IEnumerator InfoMessage(){
		// If it's level 1 and the targets haven't been destroyed triggering the door to open
		if (SceneManager.GetActiveScene().buildIndex == 3 && !gc.GetComponent<ManageObjectives>().GetObjective3Complete()) {
			phraseSelect = Random.Range (1, phrases.Length);					// Never generates the maximum number, and  index 0 resets text

			infoMsg.text = phrases [phraseSelect];								// Set the text to the randomly selected text

			yield return new WaitForSeconds (2.0f);
			infoMsg.text = "";													// Reset the text
			yield return new WaitForSeconds (0.5f);
			phraseSelect = 0;													// So Coroutine can be called again when done
		}
	}
}
