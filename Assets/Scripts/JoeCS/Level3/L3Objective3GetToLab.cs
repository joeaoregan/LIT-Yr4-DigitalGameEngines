using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L3Objective3GetToLab : MonoBehaviour {

	GameObject player;																// Get the player
	GameObject gc;																	// Get the game controller

	public Text actionText;															// Display a message for the player
	public ObjectiveCounter objectiveCounter;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");   					// Locate the Player
		gc = GameObject.FindWithTag ("GameController");
	}

	void OnTriggerEnter (Collider other)                        					// Called whenever anything goes into a trigger
	{
		if(other.gameObject == player)                          							
		{
			objectiveCounter.incrementObjectives ();
			StartCoroutine (ObjectiveComplete ());
		}
	}

	IEnumerator ObjectiveComplete(){
		if (!gc.GetComponent<ObjectiveComplete>().GetToLab()) {
			gc.GetComponent<ObjectiveComplete> ().SetGetToLab (true);				// Mark objecive as completed (stops message showing repeatedly, and incrementing objectives)

			actionText.text = "Objective 3:\nGet To The Lab Complete";
			yield return new WaitForSeconds(2);
			actionText.text = "";													// Clear the message
			yield return new WaitForSeconds (0.5f);									// Wait for the amount of time to allow the text to be cleared

			actionText.GetComponent<Text> ().text = "Objective 4:\nFind The Girl";	// Then display the next objective
			yield return new WaitForSeconds (2.0f);									// Wait for the amount of time
			actionText.GetComponent<Text> ().text = "";								// Then clear the message
		}
	}
}
