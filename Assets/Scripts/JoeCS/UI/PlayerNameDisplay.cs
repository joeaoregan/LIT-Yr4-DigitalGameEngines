using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameDisplay : MonoBehaviour {

	public Text nameText;

	// Use this for initialization
	void Start () {
		string name = PlayerPrefs.GetString ("PlayerName");
		nameText.text = name;
	}
}
