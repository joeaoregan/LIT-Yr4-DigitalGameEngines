using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToEnterNameText : MonoBehaviour {

	public Text readyText;

	// Use this for initialization
	void Start () {
		string name = PlayerPrefs.GetString ("PlayerName");
		readyText.text = "\nTime For A New Player\n" + name;
	}
}
