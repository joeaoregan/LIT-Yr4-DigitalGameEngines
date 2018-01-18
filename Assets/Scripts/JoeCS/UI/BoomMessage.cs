using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomMessage : MonoBehaviour {

	public Text messageText;

	// Use this for initialization
	void Start () {
		//string name = PlayerPrefs.GetString ("PlayerName");
		messageText.text = "Boom";
	}
}
