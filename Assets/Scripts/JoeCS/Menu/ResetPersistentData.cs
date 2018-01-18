using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPersistentData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Score", 0);	// Reset score
		PlayerPrefs.SetInt ("Ammo", 0);		// Reset the ammo	
	}
}
