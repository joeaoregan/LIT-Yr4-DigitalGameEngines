using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameDisplay : MonoBehaviour {

	public Text nameText;

	// Use this for initialization
	void Start () {
		int random = Random.Range (1, 6);

		string name = PlayerPrefs.GetString ("PlayerName");		// Load the entered name

		name = name.Replace ("\n", "");							// Get rid of new line
		name = name.Replace ("\r", "");							// Get rid of carriage return

		// Choose a name at random if none entered
		if (name == "" || name == "\n") {
			if (random == 1)
				name = "Gertrude";
			else if (random == 2)
				name = "Bananaman";
			else if (random == 3)
				name = "Pat McGroin";
			else if (random == 4)
				name = "Action Hank";
			else if (random == 5)
				name = "Seymour Butts";
		}

		PlayerPrefs.SetString ("PlayerName", name);				// Set the new name

		nameText.text = name;									// Display the name
	}
}
