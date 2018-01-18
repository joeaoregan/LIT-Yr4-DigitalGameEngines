using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ammoInteract : MonoBehaviour {
	
	public float distanceTo;

	Text infoMsg;

	private GameObject mainCam;
	private GameObject player;

	void Start () {
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindWithTag("Player");
	}

	void Update () {
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();	
	}

	void OnMouseOver(){
		if (distanceTo < 2.0f) {

			if (SceneManager.GetActiveScene().buildIndex == 3 && player.GetComponent<WeaponSelect>().GetHasGun() == false)
				infoMsg.text = "You will need to find a gun first";            	// Display message
			else
				infoMsg.text = "More ammo is always good"; 						// Display message

			//StartCoroutine (ClearText ());									// Stops working right when not enabled								
		}
	}

	void OnMouseExit(){
		infoMsg.text = "";
	}

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2);									// After 2 seconds
		infoMsg.text = "";														// Reset the text
	}
}
