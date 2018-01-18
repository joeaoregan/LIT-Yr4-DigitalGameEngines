// Joe O'Regan
// Level 3
// Close Zombie Spawn Point Doors

// Close the door if the button is active
// And deactivate the spawn point

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseZombieSpawnDoor : MonoBehaviour {

	public GameObject door;				// Door to close
	public GameObject doorSwitch;		// Door switch needs to be active (green)
	public GameObject spawnPoint;		// Spawn point to disable

	public AudioClip clip;
	AudioSource doorAudio;

	GameObject mainCam;
	public float distanceTo;

	Text infoMsg;

	// Use this for initialization
	void Start () {
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();
		doorAudio = GetComponent<AudioSource> ();
	}

	void Update() {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();
	}

	void OnMouseOver() {
		if (distanceTo < 2.0f) {
			if (Input.GetButtonDown ("Action") && doorSwitch.activeInHierarchy && !door.activeInHierarchy) { // if the switch is turned on, and the door is not already active (Otherwise keeps playing sound every time button pressed
				infoMsg.text = "Press Action Button To Open";
				StartCoroutine ("ClearText");
				CloseDoor ();
			} else if (!doorSwitch.activeInHierarchy) {
				infoMsg.text = "Complete The Objective To Activate";
				StartCoroutine ("ClearText");
			}else if (door.activeInHierarchy) {
				infoMsg.text = "The Door Is Jammed Shut";
				StartCoroutine ("ClearText");
			}
		}
	}

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2);
		infoMsg.text = "";
	}

	void CloseDoor(){
		doorAudio.clip = clip;
		doorAudio.Play ();

		door.SetActive(true);
		spawnPoint.SetActive (false);
	}
}
