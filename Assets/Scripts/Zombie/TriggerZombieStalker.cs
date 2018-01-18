using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZombieStalker : MonoBehaviour {

	public bool triggerZombie = false;

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			triggerZombie = true;
		}
	}
}
