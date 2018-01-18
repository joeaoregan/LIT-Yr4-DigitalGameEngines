using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpGun : MonoBehaviour {

	public float distanceTo;

	public Text actionText;

	public GameObject playerGun;
	//public GameObject pickupGun;
	public GameObject ammoDisplay;
	public GameObject targetDisplay;
	public GameObject hasGunObjective;

	private AudioSource pickupAudio;

	private GameObject mainCam;
	private GameObject player;

	// Use this for initialization
	void Start () {
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindWithTag("Player");
		pickupAudio = GetComponent<AudioSource> ();		
	}
	
	// Update is called once per frame
	void Update () {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();	
		
	}

	void OnMouseOver() {
		//Debug.Log ("Mouse over Chainsaw");

		if (distanceTo < 2.0f) {
			actionText.text = "Take 9mm Pistol";
			StartCoroutine ("ClearText");							// Clear text after 2 seconds

			if (Input.GetButtonDown ("Action")) {  
					PickupGun ();									// Get the gun
			}
		}
	}

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2);
		actionText.text = "";
	}

	void PickupGun(){
		player.GetComponent<WeaponSelect> ().HasGun(true);			// Enable the gun for the player

		this.gameObject.SetActive (false);							// Hide the pickup gun object

		playerGun.gameObject.SetActive (true);						// Show the Player gun
		ammoDisplay.gameObject.SetActive (true);					// Show the ammo count text on UI panel
		targetDisplay.gameObject.SetActive (true);					// Show the targets to kill on UI panel
		hasGunObjective.gameObject.SetActive (true);				// Activate the hasGun objective object

		pickupAudio.Play();                                        	// play the sound effect
	}
}
