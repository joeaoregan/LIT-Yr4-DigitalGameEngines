using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpGun : MonoBehaviour {

	public float distanceTo;

	Text infoMsg;

	public GameObject playerGun;
	//public GameObject pickupGun;
	public GameObject ammoText;
	public GameObject targetText;
	public GameObject hasGunObjective;

	private AudioSource pickupAudio;

	private GameObject mainCam;
	private GameObject gc;
	private GameObject player;

	// Use this for initialization
	void Start () {
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		gc = GameObject.FindGameObjectWithTag ("GameController");
		player = GameObject.FindWithTag("Player");
		pickupAudio = GetComponent<AudioSource> ();		
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();			
	}

	void OnMouseOver() {
		//Debug.Log ("Mouse over Chainsaw");

		if (distanceTo < 2.0f) {
			infoMsg.text = "Take 9mm Pistol";
			StartCoroutine ("ClearText");							// Clear text after 2 seconds

			if (Input.GetButtonDown ("Action") && gc.GetComponent<ManageZombies> ().totalZombieKills () == 0) {  
				StartCoroutine(PickupGun ());						// Get the gun
			}
		}
	}

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2);
		infoMsg.text = "";
	}

	IEnumerator PickupGun(){
		player.GetComponent<WeaponSelect> ().HasGun(true);			// Enable the gun for the player

		playerGun.gameObject.SetActive (true);						// Show the Player gun
		ammoText.gameObject.SetActive (true);						// Show the ammo count text on UI panel
		targetText.gameObject.SetActive (true);						// Show the targets to kill on UI panel
		hasGunObjective.gameObject.SetActive (true);				// Activate the hasGun objective object

		pickupAudio.Play();                                        	// play the sound effect

		yield return new WaitForSeconds (2);

		this.gameObject.SetActive (false);							// Hide the pickup gun object
	}
}
