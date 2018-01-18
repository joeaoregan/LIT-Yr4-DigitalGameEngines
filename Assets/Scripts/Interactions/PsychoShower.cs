// Joe O'Regan
// Level 1
// Interact with shower
// Plays Audio when entering trigger

// Displays random message when in range
// Increases the sfx volume on the audio mixer (range -80 to 20) when the bass sound is playing

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PsychoShower : MonoBehaviour {

	public AudioMixer mainMixer;   										 				// Reference to main audio mixer
	float musVol, fxVol;																// Hold audio mixer levels for FX and Music

	public float distanceTo;															// Raycast distance to object
	public string[] phrases;
	//public Text[] phrases;

	private GameObject mainCam;															// Get the first person controller camera used for information message display
	private Text infoMsg;																// Replaces actionText as information/action text in game
	//private GameObject gc;															// Game controller
	AudioSource psychoAudio;															// Get the audio source
	private bool dontOverWrite;

	void Start () {
		//gc = GameObject.FindWithTag ("GameController");								// Locate the game controller
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();			// Get the action/information text object
		psychoAudio = GetComponent<AudioSource>();
		dontOverWrite = false;
	}

	// Check raycast value
	void Update () {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();
	}

	private void OnTriggerEnter(Collider Player)
	{
		if (!dontOverWrite) {
			int select = Random.Range (0, phrases.Length);								// Change to array of phrases entered in editor
			infoMsg.text = phrases[select];

			StartCoroutine ("ClearText");	
		}

		StartCoroutine(BassAudio ());												// Play the psycho theme audio
	}

	IEnumerator BassAudio() {
		Debug.Log ("Play Psycho Theme");

		//mainMixer.GetFloat ("SFXVol", out fxVol);									// Get SFX volume from main mixer
		//mainMixer.SetFloat("SFXVol", fxVol + 10);									// Increase SFX volume level
		//mainMixer.SetFloat("MusicVol", -20);										// drop music audio level

		psychoAudio.Play();    														// Play the Psycho them music

		yield return new WaitForSeconds (psychoAudio.clip.length);					// Wait for clip to play
		//mainMixer.SetFloat("MusicVol", vol);										// drop music audio level	
		//mainMixer.SetFloat("SFXVol", fxVol);										// drop music audio level
	}

	private void OnTriggerExit()
	{
		StartCoroutine ("ClearText");
	}

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2.0f);
		infoMsg.text = "";
		dontOverWrite = false;
		//dontOverWrite = false;
	}

}
