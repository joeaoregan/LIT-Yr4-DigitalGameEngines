using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayNameMenu : MonoBehaviour {

	public Text nameMsgText;
	public string playerName;

	// Use this for initialization
	void Start () {
		playerName = PlayerPrefs.GetString ("PlayerName");
		nameMsgText.text = "Select An Option " + playerName; 
	}
}
