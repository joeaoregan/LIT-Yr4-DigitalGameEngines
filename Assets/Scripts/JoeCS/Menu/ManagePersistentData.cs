using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagePersistentData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene().buildIndex <= 3){
			PlayerPrefs.SetInt ("Score", 0);		// Reset score
			PlayerPrefs.SetInt ("Ammo", 0);			// Reset the ammo	
			PlayerPrefs.SetInt ("Health", 100);		// Reset the health
			PlayerPrefs.SetInt ("ZombieCount", 0);	// Reset the total number of zombies killed
			PlayerPrefs.SetInt ("HeadshotCount", 0);// Reset the total headshots
		}

		// When editing levels, health can be saved as 0 when exiting game
		if (SceneManager.GetActiveScene ().buildIndex >= 3) {
			if (PlayerPrefs.GetInt ("Health") <= 0)
				PlayerPrefs.SetInt ("Health", 100);
		}
	}
}
