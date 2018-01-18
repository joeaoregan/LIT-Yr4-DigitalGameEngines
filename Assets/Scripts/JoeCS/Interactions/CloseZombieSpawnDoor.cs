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
			infoMsg.text = "Press Action Button";
			StartCoroutine ("ClearText");

			if(Input.GetButtonDown("Action") && doorSwitch.activeInHierarchy) {
				CloseDoor();
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
