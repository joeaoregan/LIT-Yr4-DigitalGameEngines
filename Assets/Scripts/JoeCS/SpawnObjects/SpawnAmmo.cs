/*
 * If the Player runs out of ammo before shooting the targets
 * spawn  the ammo again in the same place (because I'm too lazy to move it)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnAmmo : MonoBehaviour {

	public GameObject ammo1;
	public GameObject ammo2;

	//public GameObject hasGun;
	public GameObject targetsDestroyed;

	//public Text actionText;

	public ObjectiveCounter completeObjectives;
	public GlobalAmmo globalAmmoCount;

	private Text infoMsg;

	void Start () {
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();				// Find the information message text object
	}

	// Update is called once per frame
	void Update () {
		//if (!targetsDestroyed.activeInHierarchy && hasGun.activeInHierarchy) {			// If the player hasn't finished shooting targets, and has the gun
		//	ammo1.SetActive(true);
		//	ammo2.SetActive (true);
		//
		if (completeObjectives.getObjectiveCount () >= 2 && globalAmmoCount.getAmmo() == 0	// If the player has got ammo and gun already
			&& (!ammo1.activeInHierarchy || !ammo2.activeInHierarchy)) {					// And the ammo crates aren't visible
				ammo1.SetActive(true);
				ammo2.SetActive (true);
				StartCoroutine (BeCondescending ());
			}
		//}
	}

	IEnumerator BeCondescending(){
		infoMsg.text = "Get more ammo, and shoot target bullseye\nThe shiney red dot in target center";
		yield return new WaitForSeconds (3);												// Longer message/longer time
		infoMsg.text = "";
	}
}
