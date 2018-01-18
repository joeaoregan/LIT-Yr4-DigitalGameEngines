// Joe O'Regan
// All Levels
// Animate the crosshairs on the HUD panel

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairsAnimation : MonoBehaviour {
    
    private Animation anim;

	public float fireRate = 0.25f;						// How often a Player can fire
	private float nextFire;								// Sets the time the weapon can fire next, fire rate

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update () {
		//if (Input.GetButton("Fire1") || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire1G") || Input.GetAxisRaw("FireRT") > 0)
		if ((Input.GetButton("Fire1") || Input.GetButtonDown("Fire1") || Input.GetAxisRaw("Fire1") > 0) && Time.time > nextFire)	// left mouse, button 1 gamepad, or gamepad right trigger
		{
			nextFire = Time.time + fireRate;														// Set the time the next fire can occur to the current time + the fire rate

            anim.Play();
        }
	}
}
