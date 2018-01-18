using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPersistentData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Score", 0);		// Reset score
		PlayerPrefs.SetInt ("Ammo", 0);			// Reset the ammo	
		PlayerPrefs.SetInt ("Health", 100);		// Reset the health
		PlayerPrefs.SetInt ("ZombieCount", 0);	// Reset the total number of zombies killed
		PlayerPrefs.SetInt ("HeadshotCount", 0);// Reset the total headshots
	}
}
