using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMessage : MonoBehaviour {

	public Text gameOverText;
	public Text scoreText;
	public Text zombieText;

	//GameObject gc;				// Game controller

	// Use this for initialization
	void Start () {
		//gc = GameObject.FindWithTag ("GameController");

		//int score = gc.GetComponent<ManageScore> ().currentScore;
		int score = PlayerPrefs.GetInt("Score");
		int zombies = PlayerPrefs.GetInt ("ZombieCount");

		string name = PlayerPrefs.GetString ("PlayerName");
		gameOverText.text = "\nGame Over\n" + name;

		scoreText.text = "Your Score: " + score;
		zombieText.text = "Zombies Killed: " + zombies;
	}
}
