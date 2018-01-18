using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string name = PlayerPrefs.GetString ("PlayerName");
		if (name == "")
			name = "Gertrude";


	}
}
