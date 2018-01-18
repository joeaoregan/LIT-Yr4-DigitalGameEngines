/*
 	Joe O'Regan
 	Level 1
 	Objective 3: When finished open the door to the room with the zombies
 	
	When the targets objective is complete,
	Open the zombie room door
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Objective3OpenDoors : MonoBehaviour {

	//public GameObject targetsDestroyed;	// Targets objective
	public GameObject zombieDoor;			// Door to open

	// Use this for initialization
	void Start () {
		//zombieDoor.GetComponent
		//if (targetsDestroyed.activeInHierarchy) {	// Attach to targets objective instead
		Vector3 doorRotation = new Vector3 (0, 95, 0);

		Vector3 doorOpen = new Vector3 (10.5f, 2.58f, -8.6f);
		//Quaternion doorRotate = new Quaternion (0, 95, 0, 1);

		//zombieDoor.transform.SetPositionAndRotation(doorOpen, doorRotate);

			//zombieDoor.transform.rotation = doorRotation;

		//}
		//zombieDoor.transform.Rotate(doorRotation);
		zombieDoor.transform.position = doorOpen;
		zombieDoor.transform.Rotate (doorRotation);
	}
}
