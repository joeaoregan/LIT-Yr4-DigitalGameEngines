/*
 * If the Player runs out of ammo before shooting the targets
 * spawn  the ammo again in the same place (because I'm too lazy to move it)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L3RespawnAmmo : MonoBehaviour {

	public GameObject ammo1;
	public GameObject ammo2;

	public GlobalAmmo globalAmmoCount;

//	public Text actionText;
	private Text infoMsg;																	// Replaces actionText, for displaying information messages


	void Start () {
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();				// Locate the information text object
	}

	// Update is called once per frame
	void Update () {
		if (globalAmmoCount.getAmmo() == 0	// If the player has run out of ammo
			&& (!ammo1.activeInHierarchy || !ammo2.activeInHierarchy)) {					// And the ammo crates aren't visible
				ammo1.SetActive(true);
				ammo2.SetActive (true);
				StartCoroutine (BeCondescending ());
		}
	}

	IEnumerator BeCondescending(){
		infoMsg.text = "Good thing bullets are cheap";
		yield return new WaitForSeconds (3);												// Longer message/longer time
		infoMsg.text = "";
	}
}
