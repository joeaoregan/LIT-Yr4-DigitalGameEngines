using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpChainsaw : MonoBehaviour {

	//public GameObject playerChainsaw;
	//public GameObject pickupChainsaw;

	public float distanceTo;

	Text infoMsg;

	private GameObject mainCam;
	private GameObject gc;
	private GameObject player;

	private AudioSource pickupAudio;

	private float nextMessage;			// When can the next action message be shown
	private float messageRate = 2.0f;	// Time between changing messages

	private bool readyToPickup;			// Can the chainsaw be picked up yet? (have to shoot a zombie 1st)

	// Use this for initialization
	void Start () {
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		gc = GameObject.FindGameObjectWithTag ("GameController");
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();
		pickupAudio = GetComponent<AudioSource> ();		

		readyToPickup = false;
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();	
		if (gc.GetComponent<ManageZombies> ().totalZombieKills () >= 1)
			readyToPickup = true;
	}

	void OnMouseOver() {
		//Debug.Log ("Mouse over Chainsaw");

		if (distanceTo < 2.0f) {
			if (Time.time > nextMessage) {
				nextMessage = Time.time + messageRate;
				infoMsg.text = "Get The Chainsaw";
				StartCoroutine ("ClearText");
			}

			if (Input.GetButtonDown ("Action")) {  
				//PickupChainsaw ();	// test
				if (readyToPickup) {
					StartCoroutine(PickupChainsaw ());
				} else {
					infoMsg.text = "Chainsaw!!!\nTest Out The Gun First";
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

	IEnumerator PickupChainsaw(){
		player.GetComponent<WeaponSelect> ().HasChainSaw (true);	// Enable the chainsaw for the player

		infoMsg.text = "Time To Slice And Dice";
		nextMessage = Time.time + messageRate;
		StartCoroutine ("ClearText");
		//playerChainsaw.SetActive (true);
		//pickupChainsaw.SetActive (false);
		pickupAudio.Play();                                        	// play the sound effect

		yield return new WaitForSeconds (pickupAudio.clip.length);

		this.gameObject.SetActive (false);
	}
}
