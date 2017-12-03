/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour {

    public float DistanceFromTarget;
    float ToTarget;
    	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) {
            ToTarget = hit.distance;
            DistanceFromTarget = ToTarget;
        }
	}

    public float getDistanceFromTarget() { return DistanceFromTarget; }                                     // Access the distance to a target in OpenDoubleDoors script
}
*/
