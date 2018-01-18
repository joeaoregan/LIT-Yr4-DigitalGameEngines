using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomMessage : MonoBehaviour {

	public Text messageText;

	public Text scoreText;
	public Text totalKillsText;
	public Text totalHeadshotsText;

	// Use this for initialization
	void Start () {
		//string name = PlayerPrefs.GetString ("PlayerName");
		messageText.text = "Boom";
	}

	void Update(){
		scoreText.text = "Score: " + PlayerPrefs.GetInt ("Score");
		totalKillsText.text = "Total Kills: " + PlayerPrefs.GetInt ("ZombieCount");
		totalHeadshotsText.text = "Total Headshots: " + PlayerPrefs.GetInt ("HeadshotCount");
	}
}
