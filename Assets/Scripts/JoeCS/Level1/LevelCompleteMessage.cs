using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteMessage : MonoBehaviour {

	public Text levelText;

	public Text objectivesText;
	public Text zombiesText;
	public Text scoreText;

	//public ObjectiveCounter objectiveCount;

	GameObject gc;

	// Use this for initialization
	void Update () {
		gc = GameObject.FindWithTag ("GameController");
		int zombieKills = gc.GetComponent<ManageZombies> ().currentTargets;
		int score = gc.GetComponent<ManageScore> ().currentScore;

		string name = PlayerPrefs.GetString ("PlayerName");

		if (SceneManager.GetActiveScene ().buildIndex == 3) {
			levelText.text = "Level 1 Complete\n" + name;
			objectivesText.text = "Objectives 5/5";
		} else if (SceneManager.GetActiveScene ().buildIndex == 4) {
			levelText.text = "Level 2 Complete\n" + name;	
			objectivesText.text = "Objectives 2/2";	
		} else if (SceneManager.GetActiveScene ().buildIndex == 5) {
			levelText.text = "Level 3 Complete\n" + name;
			objectivesText.text = "Objectives 4/4";
		}

		zombiesText.text = "Zombies Killed: " + zombieKills;
		scoreText.text = "Score: " + score;
	}
}
