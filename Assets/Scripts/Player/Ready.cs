// Joe O'Regan
// Levels 2 & 3

// Don't move the zombies until the player triggers the movement

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready : MonoBehaviour {
	bool ready;

	void Start () {
		ready = false;
	}

	public bool ReadyToStart () {
		return ready;
	}

	public void SetReady(bool set) {
		ready = set;
	}
}
