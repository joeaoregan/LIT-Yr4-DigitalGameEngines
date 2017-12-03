using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageScore : MonoBehaviour {

    public int currentScore;
    public int InternalScore;
    public Text scoreText;
    	
	// Update is called once per frame
	void Update () {
        InternalScore = currentScore;
        scoreText.GetComponent<Text> ().text = "" + InternalScore;
    }
}
