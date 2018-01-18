// Joe O'Regan
// All Levels

// Specific interaction

// Display message after raycasting onto ammo
// If level 1, and the player hasn't the gun
// He is told to get the gun

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ammoInteract : MonoBehaviour {
	
	public float distanceTo;
	public string[] phrases;
	private int phraseSelect;

	private Text infoMsg;
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
			/*
			if (SceneManager.GetActiveScene().buildIndex == 3 && player.GetComponent<WeaponSelect>().GetHasGun() == false)
				infoMsg.text = "You will need to find a gun first";            	// Display message
			else
				infoMsg.text = "More ammo is always good"; 						// Display message

			//StartCoroutine (ClearText ());									// Stops working right when not enabled		
			*/

			if (phraseSelect == 0)
				StartCoroutine (InfoMessage());
		}
	}

	IEnumerator InfoMessage(){
		phraseSelect = Random.Range (1, phrases.Length);						// Never generates the maximum number, and  index 0 resets text

		if (SceneManager.GetActiveScene().buildIndex == 3 && player.GetComponent<WeaponSelect>().GetHasGun() == false)
			infoMsg.text = "You will need to find a gun first";            		// Display message
		else
			infoMsg.text = phrases [phraseSelect];								// Set the text to the randomly selected text

		yield return new WaitForSeconds (2.0f);
		infoMsg.text = "";														// Reset the text
		yield return new WaitForSeconds (0.5f);
		phraseSelect = 0;														// So Coroutine can be called again when done
	}

	/*
	IEnumerator ClearText(){
		yield return new WaitForSeconds (2);									// After 2 seconds
		infoMsg.text = phrases[0];												// Reset the text (Leave Blank For This Reason)
	}


	void OnMouseExit(){
		infoMsg.text = "";
	}
	*/
}
