// Joe O'Regan
// Level 1
// Interact with guitar
// Plays Audio when action button pressed
// Displays random message when in range

// Increases the sfx volume by 10 on the audio mixer (range -80 to 20) when the bass sound is playing

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SlapTheBass : MonoBehaviour {

	public AudioMixer mainMixer;   										 				// Reference to main audio mixer
	float musVol, fxVol;

	public float distanceTo;															// Raycast distance to object
	public string[] phrases;
	//public Text[] phrases;

	private GameObject mainCam;															// Get the first person controller camera
	private Text infoMsg;																// Replaces actionText as information/action text in gam
	//private GameObject gc;																// Game controller
	AudioSource bassAudio;																// Get the audio source
	private bool dontOverWrite;

	void Start () {
		//gc = GameObject.FindWithTag ("GameController");									// Locate the game controller
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();			// Get the action/information text object
		bassAudio = GetComponent<AudioSource>();
		dontOverWrite = false;
	}

	// Check raycast value
	void Update () {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();
	}

	private void OnMouseOver()
	{
		if (!dontOverWrite) {
			if (distanceTo <= 2.0f) {	
				/*
			int select = Random.Range (1, 4);

			if (select == 1) {
				infoMsg.text = "Slap The Bass";
			} else if (select == 2) {
				infoMsg.text = "Play That Funky Music";
			} else {
				infoMsg.text = "Bulls On Parade (Bass Solo)\nRage Against The Machine";
			}
			*/

				int select = Random.Range (0, phrases.Length);								// Change to array of phrases entered in editor
				infoMsg.text = phrases[select];
				//infoMsg.text = phrases[select];
				//infoMsg.text = phrases [0];

				StartCoroutine ("ClearText");

				if (Input.GetButtonDown ("Action"))
					BassAudio ();															// Play the bond theme audio
			
				dontOverWrite = true;
			}
		}

		if (Input.GetButtonDown ("Action") && distanceTo <= 2.0f)
			StartCoroutine(BassAudio ());																	// Play the bond theme audio
	}

	private void OnMouseExit()
	{
		if (distanceTo <= 2.0f) {
				infoMsg.text = "That Would Make A Funky Weapon";
				StartCoroutine ("ClearText");
		}

		dontOverWrite = false;
	}

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2.0f);
		infoMsg.text = "";
		//dontOverWrite = false;
	}

	IEnumerator BassAudio() {
		//mainMixer.GetFloat ("MusicVol", out musVol);
		mainMixer.GetFloat ("SFXVol", out fxVol);

		//mainMixer.SetFloat("MusicVol", vol * 0.75f);									// drop music audio level
		//mainMixer.SetFloat("MusicVol", 0.1f);									// drop music audio level

		mainMixer.SetFloat("SFXVol", fxVol + 10);									// drop music audio level
		//mainMixer.SetFloat("MusicVol", -20);									// drop music audio level

		bassAudio.Play();    															// Play the Rage Against The Machine bass clip (programmed in GuitarPro by me) 

		yield return new WaitForSeconds (bassAudio.clip.length);
		//mainMixer.SetFloat("MusicVol", vol);											// drop music audio level	
		//mainMixer.SetFloat("SFXVol", 0);									// drop music audio level		
		//mainMixer.SetFloat("MusicVol", musVol);									// drop music audio level	
		mainMixer.SetFloat("SFXVol", fxVol);									// drop music audio level
	}
}
