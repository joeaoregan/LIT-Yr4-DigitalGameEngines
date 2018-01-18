using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScoreboard : MonoBehaviour {

	public Text accuracy;
	public Text playerName;
	public Text shotsHits;
	public Text record;

	public GunFire gunFire;

	int shots;
	int hits;
	int percent;

	int recordPercent;
	string recordName;
	string currentPlayer;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("TargetPercent", 0);
		//PlayerPrefs.SetString ("TargetName", "Joe");

		recordName = PlayerPrefs.GetString ("TargetName");
		recordPercent = PlayerPrefs.GetInt ("TargetPercent");
		if (recordPercent > 0)
			record.text = "Record: " + recordName + " " + recordPercent + "%";

		shots = 100;
		//hits = 0;
		//percent = 0;

		//accuracy.text = shots.ToString + "%";
		accuracy.text = "0%";
		currentPlayer = PlayerPrefs.GetString ("PlayerName");
		playerName.text = currentPlayer;
	}
	
	// Update is called once per frame
	void Update () {
		shotsHits.text = "Shots: " + shots + " Hits: " + hits;
		shots = gunFire.ShotsFired();			// Get the shots fired

		if (shots > 0)
			percent = (hits * 100) / shots;
		accuracy.text = "" + percent + "%";

		CheckHighScore ();
	}

	public void IncrementHits(){
		hits++;
	}

	void CheckHighScore(){
		if (hits >= 14) {
			if (percent > recordPercent) {
				PlayerPrefs.SetInt ("TargetPercent", percent);
				PlayerPrefs.SetString ("TargetName", currentPlayer);

				record.text = "Record: " + currentPlayer + " " + percent + "%";
			}	
		}
	}
}
