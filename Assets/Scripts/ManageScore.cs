using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;	// Get the build index

public class ManageScore : MonoBehaviour {

    public int currentScore;
    public int InternalScore;
    public Text scoreText;
	private int level;										// Current level of the game (build index)
	void Start() {

		level = SceneManager.GetActiveScene ().buildIndex;
		if (level > 1)
			currentScore = PlayerPrefs.GetInt("Score");		// Get the ammo from the previous level
	}
    	
	// Update is called once per frame
	void Update () {
        InternalScore = currentScore;
        scoreText.GetComponent<Text> ().text = "" + InternalScore;
    }

	public int getScore() {
		return InternalScore;
	}
}
