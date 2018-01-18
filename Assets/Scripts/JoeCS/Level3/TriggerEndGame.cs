/* Try and stop the player moving at the end of level 3 when the girl is talking
 * Couldnt get the player to stop moving
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TriggerEndGame : MonoBehaviour {
	
	//UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

	GameObject player;

	private bool roomEntered;

//	FirstPersonController fps;
		
	void Start(){
		player = GameObject.FindWithTag ("Player");
		roomEntered = false;
	}

	void Update(){
		if (roomEntered) 
			//Time.timeScale = 0;	// no good, pauses everything
		//player.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);	// doesn't affect FPS
		player.GetComponent<Rigidbody> ().mass = 50;
	}


	private void OnTriggerEnter(Collider other)
	{
		// Do chainsaw Audio & Damage
		if (other.gameObject.tag == "Player") {
			//FPSController.GetComponent<FirstPersonController> ().enabled = false;

			//GameObject.Find ("Player").GetComponent<FirstPersonController> ().enabled = false;
			//fps = GameObject.Find ("Player").GetComponent<FirstPersonController> ();
			//fps.enabled = false;
			//player.GetComponent<FirstPersonController>().enabled = false;

			Debug.Log ("Don't Move, Just Watch!!!");
			roomEntered = true;

			//GameObject.Find ("FPSController").GetComponent<FirstPersonController> ().enabled = false;
			//controller = GameObject.Find ("Player").GetComponent<FirstPersonController>();
			//controller = GameObject.Find ("FPSController").GetComponent<FirstPersonController>();
			//controller.enabled = false;

			//player.enabled = false;
			//controller.m_Walkspee

			player.GetComponent<WeaponSelect> ().SelectGun ();						// Change back to gun, so ending makes sense
		}
	}
}
