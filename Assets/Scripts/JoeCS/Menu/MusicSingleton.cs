/*
 	Use singleton pattern to keep music playing between scenes in menu
	Music changes when game loads
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicSingleton : MonoBehaviour {

	public AudioSource audio;								// Audio source to use between scenes
	public AudioClip clip;									// Song to play over scenes

	public static MusicSingleton instance = null;			// Singleton used to keep instance of music player

	public static MusicSingleton Instance {
		get { return instance; }							// Returns an instance of the music player
	}

	// Use this for initialization
	void Awake () {		
		if (instance != null && instance != this) {			// If there is an existing music player
			Destroy (this.gameObject);						// Destroy this one, don't need to
			return;											// skip the rest
		} else {											// Otherwise
			instance = this;								// There is no music player, use this
		}

		DontDestroyOnLoad (this.gameObject);				// Don't destroy when the scene loads (object script is attached to)

		audio.clip = clip;									// Load the clip
		audio.Play ();										// Start playing my awesome menu music
	}
	void Update() {
		if (SceneManager.GetActiveScene ().buildIndex == 3)	// If level 1 has begun
			Destroy (this.gameObject);						// Destroy the object
	}
}
