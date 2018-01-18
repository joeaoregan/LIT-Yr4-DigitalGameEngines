using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;	// Get the build index

public class ManageScore : MonoBehaviour {

    public int currentScore;
    public int InternalScore;
    public Text scoreNumText;											// UI display the score
	private int levelIndex;												// Current level of the game (build index)

	private Animation anim;												// Animate the score text

	void Start() {
		anim = scoreNumText.gameObject.GetComponent<Animation>();		// Get animation component
		levelIndex = SceneManager.GetActiveScene ().buildIndex;

		if (levelIndex > 3)
			currentScore = PlayerPrefs.GetInt("Score");					// Get the score from the previous level
	}
    	
	// Update is called once per frame
	void Update () {
		InternalScore = currentScore;
		//scoreNumText.GetComponent<Text> ().text = "" + InternalScore;
		scoreNumText.text = "" + InternalScore;
    }

	public int getScore() {
		return InternalScore;
	}

	public void UpdateScore(int amount){
		currentScore += amount;
	}

	public void BonusScore(int amount){
		currentScore += amount;
		anim.Play("ScoreNumberText");									// Animate the text
	}
}
