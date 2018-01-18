/* Try and stop the player moving at the end of level 3 when the girl is talking
 * Couldnt get the player to stop moving
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TriggerEndGame : MonoBehaviour {

	GameObject player;
FirstPersonController fps;
		
	void Start(){
		player = GameObject.FindWithTag ("Player");
	}


	private void OnTriggerEnter(Collider other)
	{
		// Do chainsaw Audio & Damage
		if (other.gameObject.tag == "Player") {
			//FPSController.GetComponent<FirstPersonController> ().enabled = false;

			//GameObject.Find ("Player").GetComponent<FirstPersonController> ().enabled = false;
			//fps = GameObject.Find ("Player").GetComponent<FirstPersonController> ();
			//fps.enabled = false;
			player.GetComponent<FirstPersonController>().enabled = false;
		}

		player.GetComponent<WeaponSelect> ().SelectGun ();
	}
}
