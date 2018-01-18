using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    //public ManageScore score;
    public int scoreValue = 25;

	GameObject gc;										// Game Controller

	void Start(){
		gc = GameObject.FindWithTag ("GameController");
	}

    void DeductPoints(int DamageAmount)
    {
		gc.GetComponent<ManageScore> ().currentScore += scoreValue;
        //score.currentScore += scoreValue;
    }
}
/*
GameObject score;
public int scoreValue = 25;

void Start(){
	//score = FindWithTag ("ScoreController");
	score = GameObject.FindGameObjectWithTag ("ScoreController");
}

void DeductPoints(int DamageAmount)
{
	score.GetComponent<ManageScore>().currentScore += scoreValue;
	Debug.Log ("Score added: " + scoreValue);
}
*/