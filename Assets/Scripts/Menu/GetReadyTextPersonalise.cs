using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetReadyTextPersonalise : MonoBehaviour {

	public Text readyText;

	// Use this for initialization
	void Start () {
		string name = PlayerPrefs.GetString ("PlayerName");
		readyText.text = "\nGet Ready\n" + name;
	}
}
