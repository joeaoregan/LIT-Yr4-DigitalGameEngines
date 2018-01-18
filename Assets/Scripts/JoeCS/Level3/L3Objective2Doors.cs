using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L3Objective2Doors : MonoBehaviour {

	public GameObject door1;
	public GameObject door2;
	public GameObject labDoor;

	public Text actionText;

	public ObjectiveCounter objectiveCounter;

	public Camera playerCam;
	public Camera doorCam;
	public Canvas playerHUD;

	GameObject gc;

	// Use this for initialization
	void Start () {
		gc = GameObject.FindWithTag ("GameController");
	}
	
	// Update is called once per frame
	void Update () {		
		if (door1.activeInHierarchy && door2.activeInHierarchy && !gc.GetComponent<ObjectiveComplete> ().doorsClosed())	{	// If the doors to the zombie spawn points are closed
			GameObject.FindWithTag ("GameController").GetComponent<ObjectiveComplete> ().setDoorsClosed (true);				// Set the gamecontroller variable true

			objectiveCounter.incrementObjectives ();																		// Increment the number of complete objectives

			StartCoroutine (ObjectiveComplete ());
		}
	}

	IEnumerator ObjectiveComplete(){
		gc.GetComponent<ObjectiveComplete> ().SetZombiesKilled (true);

		actionText.text = "Objective 2:\nClose Doorways To Great Hall Complete";
		yield return new WaitForSeconds(2);
		actionText.text = "";																// Clear the message
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
