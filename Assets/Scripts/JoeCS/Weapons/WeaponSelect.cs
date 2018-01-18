using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponSelect : MonoBehaviour {

	//public GameObject gun;
	//public GameObject chainsaw;
	public GameObject[] weapons;	// Weapons array

	private bool hasGun;
	private bool hasChainsaw;
	private bool hasCrowbar;

	private int activeWeaponIndex;

	private bool pressed;

	// Use this for initialization
	void Start () {
		hasGun = false;
		hasChainsaw = false;
		hasCrowbar = false;

		activeWeaponIndex = 0;
		//Debug.Log ("Start - Weapon Index: " + activeWeaponIndex);
		pressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("UpDown") == 0)
			pressed = false;								// Button released
		
		if ((Input.GetAxisRaw ("UpDown") > 0 && !pressed) || Input.GetKeyDown(KeyCode.KeypadPlus)) {
			pressed = true;
			ChangeWeaponUp();								// Up button pressed
		}
		if ((Input.GetAxisRaw ("UpDown") < 0 && !pressed) || Input.GetKeyDown(KeyCode.KeypadMinus)) {
			pressed = true;
			ChangeWeaponDown ();							// Down button pressed
		}
	}


	public void ChangeWeaponUp(){
		if (activeWeaponIndex < weapons.Length - 1)
			activeWeaponIndex++;							// increment up the list of weapons
		else
			activeWeaponIndex = 0;							// go to the start of the list

		//Debug.Log ("Up - Weapon Index: " + activeWeaponIndex);

		SelectWeapon ();
		//gun.gameObject.SetActive (false);
		//chainsaw.gameObject.SetActive (true);
	}

	public void ChangeWeaponDown(){
		if (activeWeaponIndex > 0)
			activeWeaponIndex--;							// go back down the list of weapons
		else
			activeWeaponIndex = weapons.Length - 1;			// go to the end of the list

		//Debug.Log ("Down - Weapon Index: " + activeWeaponIndex);

		SelectWeapon ();

		//gun.gameObject.SetActive (true);
		//chainsaw.gameObject.SetActive (false);
	}

	void SelectWeapon() {
		/*
		for (int i = 0; i < weapons.Length; i++) {
			if (i == activeWeaponIndex) {
				weapons [i].gameObject.SetActive (true);
			} else {
				weapons [i].gameObject.SetActive (false);
			}
		}
		*/


		if (activeWeaponIndex == 0 && hasGun)
			weapons [0].gameObject.SetActive (true);
		// else
		if (activeWeaponIndex == 1 && hasChainsaw)
			weapons [1].gameObject.SetActive (true);
		if (activeWeaponIndex == 2 && hasCrowbar)
			weapons [2].gameObject.SetActive (true);
		//else return;


		// Set other weapons as not active
		for (int i = 0; i < weapons.Length; i++) {
			if (i != activeWeaponIndex) {
				weapons [i].gameObject.SetActive (false);
			}
		}
	}


	// Needed so zombies arent shot with imaginary gun when using chainsaw/crobar weapons etc.
	public bool GunActive(){
		if(weapons[0].gameObject.activeInHierarchy) return true;
		return false;
	}

	public void HasGun(bool set){
		hasGun = set;
	}
	public void HasChainSaw(bool set){
		hasChainsaw = set;
	}
	public void HasCrowbar(bool set){
		hasCrowbar = set;
	}
}
