// Joe O'Regan
// Level 3
// Objective 2: Close the zombie spawning doors

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L3Objective2Doors : MonoBehaviour {

	//public GameObject door1;
	//public GameObject door2;

	public GameObject[] doors;

	public GameObject labDoor;

//	public Text actionText;

	public ObjectiveCounter objectiveCounter;

	public Camera playerCam;
	public Camera doorCam;
	public Canvas playerHUD;

	private Text infoMsg;																	// Replaces actionText, for displaying information messages

	bool doorsAllActive;

	private GameObject gc;																	// Game controller

	// Use this for initialization
	void Start () {
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();				// Locate the information text object
		gc = GameObject.FindWithTag ("GameController");										// Locate the game controller
	}
	
	// Update is called once per frame
	void Update () {
		doorsAllActive = true;

		foreach (GameObject door in doors) {
			if (!door.activeInHierarchy) doorsAllActive = false;							// If any door is not active, set this boolean value false		
			if (doors[0].activeInHierarchy) Debug.Log("<color=green>Door 1 Closed</color>");
			if (doors[1].activeInHierarchy) Debug.Log("<color=green>Door 2 Closed</color>");
			if (doors[2].activeInHierarchy) Debug.Log("<color=green>Door 3 Closed</color>");				
		}

		//for (int i = 0; i < doors.Length; i++) {
		//	if (!doors[i].activeInHierarchy) doorsAllActive = false;							// If any door is not active, set this boolean value false	
		//}

		if (doorsAllActive)
			Debug.Log ("L3Objective2Doors: Doors All Active");

		if (doorsAllActive && !gc.GetComponent<ObjectiveComplete> ().doorsClosed ()) {
			//}
			//if (door1.activeInHierarchy && door2.activeInHierarchy && !gc.GetComponent<ObjectiveComplete> ().doorsClosed())	{	// If the doors to the zombie spawn points are closed	// Changed to any amount of spawn points
			GameObject.FindWithTag ("GameController").GetComponent<ObjectiveComplete> ().setDoorsClosed (true);				// Set the gamecontroller variable true
			//objectiveCounter.incrementObjectives ();																		// Increment the number of complete objectives

			StartCoroutine (ObjectiveComplete ());
		}
	}

	IEnumerator ObjectiveComplete(){
		//gc.GetComponent<ObjectiveComplete> ().SetZombiesKilled (true);

		infoMsg.text = "Objective 2:\nClose Doorways To Great Hall Complete";
		yield return new WaitForSeconds(2);
		infoMsg.text = "";																	// Clear the message
		//yield return new WaitForSeconds (0.5f);											// Wait for the amount of time to allow the text to be cleared

		// Switch camera view
		doorCam.enabled = true;
		playerCam.enabled = false;
		playerHUD.enabled = false;

		labDoor.GetComponent<Animator> ().SetTrigger ("Open");								// Door opening animation
		labDoor.GetComponent<BoxCollider>().enabled = false;								// Disable box collider so Player can move through door
		labDoor.GetComponent<OpenLabDoorSound>().PlayLabDoorSound();						// Play the sound of the door opening

		//actionText.GetComponent<Text> ().text = "Objective 3:\nGet To The Lab";			// Then display the next objective
		yield return new WaitForSeconds (3.0f);												// Wait for the amount of time
		//actionText.GetComponent<Text> ().text = "";										// Then clear the message

		playerCam.enabled = true;
		playerHUD.enabled = true;
		doorCam.enabled = false;
	}
}
