/*
 * Joe O'Regan
 * Level 1
 * Keep spawning ammo until the player finishes destroying the targets
 * 
 * If the Player runs out of ammo before shooting the targets
 * spawn  the ammo again in the same place (because I'm too lazy to move it)
 * 
 * Instantiating from prefabs might be a better idea
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnAmmo : MonoBehaviour {

	public GameObject ammo1;
	public GameObject ammo2;

	//public GameObject hasGun;
	//public GameObject targetsDestroyed;

	//public Text actionText;

	//public ObjectiveCounter completeObjectives;
	//public GlobalAmmo globalAmmoCount;

	private Text infoMsg;																					// HUD Information Message
	private GameObject gc;																					// Game controller
	bool done;

	void Start () {
		gc = GameObject.FindWithTag ("GameController");														// Locate the game controller
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();								// Find the information message text object
		done = false;
	}

	// Update is called once per frame
	void Update () {
		if(gc.GetComponent<ManageAmmo>().GetAmmo() <= 0){	
			if (!ammo1.activeInHierarchy)																	// if the crate isn't visible
				ammo1.SetActive (true);																		// Set it active
			if (!ammo2.activeInHierarchy)
				ammo2.SetActive (true);

			// If the objective is not complete, be a an ass about it
			//if (gc.GetComponent<ObjectiveComplete> ().HasGun ()) {
			//	if (!gc.GetComponent<ObjectiveComplete> ().TargetsDestroyed ())

			if (gc.GetComponent<ManageObjectives> ().GetObjective2Complete () && !done) {			// If player has already picked up ammo
				if (!gc.GetComponent<ManageObjectives> ().GetObjective3Complete ()) {						// And the targets haven't been destroyed
					StartCoroutine (BeCondescending ());
				}
			}
		}


		//if (!targetsDestroyed.activeInHierarchy && hasGun.activeInHierarchy) {							// If the player hasn't finished shooting targets, and has the gun
		//	ammo1.SetActive(true);
		//	ammo2.SetActive (true);
		//
		//if (completeObjectives.getObjectiveCount () >= 2 && globalAmmoCount.getAmmo() == 0// 
		//if (gc.GetComponent<ObjectiveCounter>().getObjectiveCount () >= 2 && globalAmmoCount.getAmmo() == 0	// If the player has got ammo and gun already
		//	&& (!ammo1.activeInHierarchy || !ammo2.activeInHierarchy)) {									// And the ammo crates aren't visible

		// Changed to check Objective 3 isnt completed yet
		// And spawn each ammo pickup individually, incase they werent both picked up previously
		//if (globalAmmoCount.getAmmo () == 0) {	// If the player has got ammo and gun already
	}

	// Used in target practice
	IEnumerator BeCondescending(){
		done = true;

		infoMsg.text = "Get more ammo, and shoot target bullseye\nThe shiney red dot in target center";
		yield return new WaitForSeconds (3);																// Longer message/longer time
		infoMsg.text = "";
		yield return new WaitForSeconds (5);																// Wait before reminding
	}

	void OnMouseExit(){

		done = true;
	}

}
