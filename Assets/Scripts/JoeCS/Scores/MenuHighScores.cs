using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHighScores : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string name = PlayerPrefs.GetString ("Name1");
		int score = PlayerPrefs.GetInt ("Score1");

		name = name.Replace ("\n", "");							// Get rid of new line
		name = name.Replace ("\r", "");							// Get rid of carriage return

		if (score == 0 || name == "")
			GetComponent<Text> ().text = "No High Score Set";
		else
			GetComponent<Text> ().text = "Top Score: " + name + " " + score;
	}
}
