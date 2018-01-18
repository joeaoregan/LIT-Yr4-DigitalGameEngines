// Joe O'Regan
// Intro Scene
// Instead of animating (before I figured out what I was doing wrong)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	public Text introText;

	// Use this for initialization
	void Start () {
		StartCoroutine ("TimedText");
	}

	IEnumerator TimedText(){
		yield return new WaitForSeconds (1);
		introText.text = "A Game By\nJoe O'Regan";
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene (1);					// Load Level 2
	}
}
