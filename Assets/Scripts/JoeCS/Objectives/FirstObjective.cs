using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;																		// Text object
using UnityEngine.SceneManagement;

public class FirstObjective : MonoBehaviour {
	
	private Text infoMsg;																	// Replaces actionText, for displaying information messages

	void Start () {
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();				// Locate the information text object
		StartCoroutine ("ObjectiveOne");
	}

	IEnumerator ObjectiveOne () {
		if (SceneManager.GetActiveScene().buildIndex == 4)
			infoMsg.GetComponent<Text> ().text = "Level 2\nObjective 1:\nKill All Zombies";	// Display message
		else if (SceneManager.GetActiveScene().buildIndex == 5)
			infoMsg.GetComponent<Text> ().text = "Level 3\nObjective 1:\nKill 10 Zombies";	// Display message

		yield return new WaitForSeconds (2);												// Wait for the amount of time (Coroutine time delay is separate)
		infoMsg.GetComponent<Text> ().text = "";											// Then clear the message
	}
}
