using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelNumberDisplay : MonoBehaviour {

	public Text levelText;
	private int level;

	// Use this for initialization
	void Start () {
		level = SceneManager.GetActiveScene ().buildIndex;
		level -= 2;											// Offset by 2 because of new scenes added
		levelText.text = level.ToString ();
	}
}
