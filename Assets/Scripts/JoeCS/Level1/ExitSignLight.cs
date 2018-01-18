using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSignLight : MonoBehaviour {

	public Light exitLight;
	public GameObject zombieObjective;

	// Use this for initialization
	void Start () {
		exitLight.enabled = false; 
	}
	
	// Update is called once per frame
	void Update () {
		if (zombieObjective.activeInHierarchy)
			exitLight.enabled = true; 
	}
}
