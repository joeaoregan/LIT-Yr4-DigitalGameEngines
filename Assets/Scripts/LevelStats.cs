using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStats : MonoBehaviour {

	public Text TotalKills;
	public Text TotalHeadshots;
		
	public void Update () {
		TotalKills.text = "Kills: " + PlayerPrefs.GetInt ("ZombieCount");
		TotalHeadshots.text = "Headshots: " + PlayerPrefs.GetInt ("HeadshotCount");
	}
}
