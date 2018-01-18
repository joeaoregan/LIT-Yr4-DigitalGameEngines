using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupCrowbar : MonoBehaviour {

	public float distanceTo;
	Text infoMsg;
	//public GameObject playerCrowbar;								// Switch with + and - on keyboard keypad, or up/down on gamepad, no need to show straight away

	private AudioSource pickupAudio;
	private GameObject mainCam;
	private GameObject gc;
	private GameObject player;

	private float nextMessage;										// When can the next action message be shown
	private float messageRate = 2.0f;								// Time between changing messages

	private bool readyToPickup;										// Cant get the crowbar until 2 zombies shot

	void Start () {
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		gc = GameObject.FindGameObjectWithTag ("GameController");
		player = GameObject.FindWithTag("Player");
		pickupAudio = GetComponent<AudioSource> ();		
		readyToPickup = false;
	}

	void Update () {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();	

		if (gc.GetComponent<ManageZombies> ().totalZombieKills () >= 2)
			readyToPickup = true;
	}

	void OnMouseOver() {
		if (distanceTo < 2.0f) {
			if (Time.time > nextMessage) {
				nextMessage = Time.time + messageRate;
				infoMsg.text = "Get The Crowbar";
				StartCoroutine ("ClearText");							// Clear text after 2 seconds
			}

			if (Input.GetButtonDown ("Action")) {  
				//GetCrowbar ();										// Get the crowbar
				if (readyToPickup) {
					GetCrowbar ();										// Get the crowbar
				} else {
					infoMsg.text = "Try Gun And Chainsaw First";
					nextMessage = Time.time + messageRate;

					StartCoroutine ("ClearText");
				}
			}
		}
	}

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2);
		infoMsg.text = "";
	}

	void GetCrowbar(){
		player.GetComponent<WeaponSelect> ().HasCrowbar(true);		// Enable the crowbar for the player


		//playerCrowbar.gameObject.SetActive (true);				// Show the Player crowbar
		StartCoroutine(PickedUp());

	}

	IEnumerator PickedUp(){
		pickupAudio.Play();                                        	// play the sound effect

		yield return new WaitForSeconds (pickupAudio.clip.length);

		this.gameObject.SetActive (false);							// Hide the pickup crowbar object
	}

}