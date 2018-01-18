// Joe O'Regan
// Level 1
// Objective 1 Collect The Gun
// What happens when the player collects the gun

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
	public GameObject targetsText;
	//public GameObject hasGunObjective;

	private AudioSource pickupAudio;

	private GameObject mainCam;
	private GameObject gc;
	private GameObject player;

	// Use this for initialization
	void Start () {
		//ammoText.gameObject.SetActive (false);					// Don't how the ammo count text on UI panel
		//targetText.gameObject.SetActive (false);					// Don't the targets to kill on UI panel

		ammoText.GetComponent<Text> ().text = "Objective 1:";
		targetsText.GetComponent<Text> ().text = "Find A Gun";

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
			StartCoroutine ("ClearText");									// Clear text after 2 seconds

			//if (Input.GetButtonDown ("Action") && gc.GetComponent<ManageZombies> ().totalZombieKills () == 0) {  
			//if (Input.GetButtonDown ("Action") && !gc.GetComponent<ObjectiveComplete> ().HasGun ()) {  
			if (Input.GetButtonDown ("Action") && !gc.GetComponent<ManageObjectives> ().GetObjective1Complete ()) {  
				StartCoroutine(PickupGun ());								// Get the gun
			}
		}
	}

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2);
		infoMsg.text = "";
	}

	IEnumerator PickupGun(){
		player.GetComponent<WeaponSelect> ().HasGun(true);					// Enable the gun for the player

		playerGun.gameObject.SetActive (true);								// Show the Player gun
		//ammoText.gameObject.SetActive (true);								// Show the ammo count text on UI panel
		//targetText.gameObject.SetActive (true);							// Show the targets to kill on UI panel
		//hasGunObjective.gameObject.SetActive (true);						// Activate the hasGun objective object

//		gc.GetComponent<ObjectiveComplete>().SetHasGun(true);				// Mark the objective complete, and increment completed objectives
		gc.GetComponent<ManageObjectives>().SetObjective1Complete(true);	// Mark the objective complete, and increment completed objectives

		Debug.Log ("Objective 1 Complete");

		pickupAudio.Play();                                        			// play the sound effect

		yield return new WaitForSeconds (2);

		this.gameObject.SetActive (false);									// Hide the pickup gun object
	}
}
