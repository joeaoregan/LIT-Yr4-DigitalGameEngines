using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInnerLabDoor : MonoBehaviour {

	//public GameObject labDoor;

	public Text actionText;							// UI message text

	public float distanceTo;						// Raycasting distance to an object
	public GameObject girl;							// The girl to be rescued

	GameObject gc;									// Game controller
	GameObject mainCam;								// FPS controller camera

	Animator girlAnim;								// Activate animations for girl

	// Use this for initialization
	void Start () {
		gc = GameObject.FindWithTag ("GameController");
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");

		girlAnim = girl.GetComponent<Animator> ();
	}

	void Update() {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();
	}


	void OnMouseOver() {
		if (distanceTo < 2.0f) {
			actionText.text = "Press Action Button";

			if(Input.GetButtonDown("Action")) {
				OpenDoor();
				//objectiveCounter.incrementObjectives ();							// Increment the number of complete objectives
				StartCoroutine (ObjectiveComplete ());
			}
		}
	}

	void OpenDoor(){
		GetComponent<Animator> ().SetTrigger ("Open");								// Door opening animation
		StartCoroutine(PlayDoorSound());											// Delay the sound by a fraction of a second to match the door animation
		GetComponent<BoxCollider>().enabled = false;								// Disable box collider so Player can move through door
	}

	IEnumerator ObjectiveComplete(){
		gc.GetComponent<ObjectiveComplete> ().SetGirlFound (true);					// Mark the objective as complete

		actionText.text = "Objective 4:\nFind The Girl Complete";

		yield return new WaitForSeconds (2);
		actionText.text = "";

		girlAnim.SetTrigger ("BackOff");											// Back away at first as she doesn't know who is coming through the door
		girl.GetComponent<SaveTheGirl>().GirlRescued();
	}

	IEnumerator PlayDoorSound(){
		yield return new WaitForSeconds (0.3f);
		GetComponent<AudioSource>().Play ();
	}
}
