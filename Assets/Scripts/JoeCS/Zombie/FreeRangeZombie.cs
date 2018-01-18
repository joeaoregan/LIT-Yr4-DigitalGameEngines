using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRangeZombie : MonoBehaviour {

	Transform player;
	UnityEngine.AI.NavMeshAgent nav;									
	//public bool playerInRange;											// Player has crossed trigger point

	public TriggerZombieStalker stalk;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	void Update(){
		//if (playerInRange) {
		if (stalk.triggerZombie) {											// If the boolean value has been set
			nav.SetDestination (player.position);							// Follow the player
		} else {
			nav.enabled = false;
		}
	}
}