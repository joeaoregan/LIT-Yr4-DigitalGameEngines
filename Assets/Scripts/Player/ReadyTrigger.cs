// Joe O'Regan
// Levels 2 & 3

// If the player collides with the trigger
// Move the zombies

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyTrigger : MonoBehaviour {

	public bool ValueToSet = true;

	GameObject player;

	void Start(){
		player = GameObject.FindWithTag ("Player");
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Player has triggered zombie movment");
			player.GetComponent<Ready> ().SetReady (ValueToSet);
		}
	}
}
