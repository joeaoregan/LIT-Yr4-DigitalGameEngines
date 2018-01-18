using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {


	public bool paused;
	public Text pausedText;

	// Use this for initialization
	void Start () {
		paused = false;
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
		} else {
			Time.timeScale = 1;
			pausedText.gameObject.SetActive (false);
		}
	}

}
