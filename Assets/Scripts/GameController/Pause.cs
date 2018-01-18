// Joe O'Regan
// All levels (Game controller component)
// Pause the game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
	
	public bool paused;									// Is the game paused
	public Text pausedText;								// Pause text

	Text infoMsg;

	// Use this for initialization
	void Start () {
		paused = false;
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown (KeyCode.Escape) || Input.GetButtonDown("Pause")) {
		if (Input.GetButtonDown("Pause")) {				// Escape key or xbox controller menu button
			paused = !paused;
		}

		if (paused) {
			Time.timeScale = 0;
			pausedText.gameObject.SetActive (true);
			infoMsg.gameObject.SetActive (false);
		} else {
			Time.timeScale = 1;
			pausedText.gameObject.SetActive (false);
			infoMsg.gameObject.SetActive (true);
		}
	}

}
