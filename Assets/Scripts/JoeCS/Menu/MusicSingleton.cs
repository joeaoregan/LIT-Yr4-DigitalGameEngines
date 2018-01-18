/*
 	Use singleton pattern to keep music playing between scenes in menu
	Music changes when game loads
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicSingleton : MonoBehaviour {

	AudioSource musicAudio;									// Audio source to use between scenes
	public AudioClip clip;									// Song to play over scenes
	public AudioClip[] tracks;								// Songs to play over scenes

	public static MusicSingleton instance = null;			// Singleton used to keep instance of music player

	public static MusicSingleton Instance {
		get { return instance; }							// Returns an instance of the music player
	}

	// Use this for initialization
	void Awake () {		
		musicAudio = GetComponent<AudioSource> ();

		if (instance != null && instance != this) {			// If there is an existing music player
			Destroy (this.gameObject);						// Destroy this one, don't need to
			return;											// skip the rest
		} else {											// Otherwise
			instance = this;								// There is no music player, use this
		}

		DontDestroyOnLoad (this.gameObject);				// Don't destroy when the scene loads (object script is attached to)

		musicAudio.clip = clip;								// Load the clip
		musicAudio.Play ();									// Start playing my awesome menu music
	}

	void Update() {
		if (SceneManager.GetActiveScene ().buildIndex == 3)	// If level 1 has begun
			Destroy (this.gameObject);						// Destroy the object

		if (Input.GetButton ("NextTrack"))
			NextTrack ();
		else if (Input.GetButton ("PreviousTrack"))
			PreviousTrack ();
	}

	int i;

	// get next track in list, or back to start
	public void NextTrack(){
		Debug.Log ("Next Track");
		if ( i < tracks.Length-1) i++;						// increment i
		else i = 0;											// go back to the beginning
		musicAudio.clip = tracks[i];
		musicAudio.Play ();
	}

	public void PreviousTrack(){
		Debug.Log ("Previous Track");
		if ( i > 0) i--;									// decrement i
		else i = tracks.Length-1;							// loop around to end
		musicAudio.clip = tracks[i];
		musicAudio.Play ();
	}

}
