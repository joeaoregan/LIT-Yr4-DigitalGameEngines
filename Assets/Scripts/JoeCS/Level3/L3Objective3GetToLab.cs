using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L3Objective3GetToLab : MonoBehaviour {

	private GameObject player;														// Get the player
	private GameObject gc;															// Get the game controller

//	public Text actionText;															// Display a message for the player
	//public ObjectiveCounter objectiveCounter;

	private Text infoMsg;															// Replaces actionText, for displaying information messages

	void Awake ()
	{
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();		// Locate the information text object
		player = GameObject.FindGameObjectWithTag ("Player");   					// Locate the Player
		gc = GameObject.FindWithTag ("GameController");
	}

	void OnTriggerEnter (Collider other)                        					// Called whenever anything goes into a trigger
	{
		if(other.gameObject == player)                          							
		{
			//objectiveCounter.incrementObjectives ();
			StartCoroutine (ObjectiveComplete ());
		}
	}

	IEnumerator ObjectiveComplete(){
		if (!gc.GetComponent<ObjectiveComplete>().GetToLab()) {
			gc.GetComponent<ObjectiveComplete> ().SetGetToLab (true);				// Mark objecive as completed (stops message showing repeatedly, and incrementing objectives)

			infoMsg.text = "Objective 3:\nGet To The Lab Complete";
			yield return new WaitForSeconds(2);
			infoMsg.text = "";														// Clear the message
			yield return new WaitForSeconds (0.5f);									// Wait for the amount of time to allow the text to be cleared

			infoMsg.GetComponent<Text> ().text = "Objective 4:\nFind The Girl";		// Then display the next objective
			yield return new WaitForSeconds (2.0f);									// Wait for the amount of time
			infoMsg.GetComponent<Text> ().text = "";								// Then clear the message
		}
	}
}
