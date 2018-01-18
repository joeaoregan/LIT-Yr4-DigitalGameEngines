// Joe O'Regan

// All Levels
// Add a score value when an object has been hit by a bullet
// And display animated score on canvas

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAnim : MonoBehaviour {

	public Canvas scoreCanvas;
	public Text scoreText;

    //public ManageScore score;
    public int scoreValue = 25;

	bool waitBetweenAnims;												// Wait for animation to play fully
	//GameObject gc;														// Game Controller
	private Animator animator;											// Animate the score text

	void Start(){
		animator = scoreCanvas.gameObject.GetComponent<Animator>();		// Find animator on score canvas	
		//gc = GameObject.FindWithTag ("GameController");

		waitBetweenAnims = false;
	}

    void DeductPoints(int DamageAmount)
    {
		//gc.GetComponent<ManageScore> ().currentScore += scoreValue;
		scoreText.text = scoreValue.ToString();
		//StartCoroutine (DisplayScore ());
		animator.SetTrigger("Score");	
    }

	IEnumerator DisplayScore(){
		if (!waitBetweenAnims) {
			animator.SetTrigger ("Score");	
			waitBetweenAnims = true;
			yield return new WaitForSeconds (animator.playbackTime);	// let animation play fully once
			waitBetweenAnims = false;
		}
	}
	
}