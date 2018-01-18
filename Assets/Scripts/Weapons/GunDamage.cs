// Joe O'Regan
// All Levels
// Attached to player gun

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDamage : MonoBehaviour {

    public float fireRate = 0.25f;			// Can change value in editor
	public int damageAmount = 5;			// Amount to injure by (zombies have health of 25)
    public float targetDistance;			// Distance from player, raycasting from fps controller main camera
	public float allowedRange = 15;			// How far the bullet travels
	//public GlobalAmmo ammo;

    private float nextFire;					// Time to fire next shot, mark as soon as the gun fires

	private GameObject player;				// Player fps controller
	private GameObject gc;					// Game controller

	void Start(){
		gc = GameObject.FindWithTag ("GameController");
		player = GameObject.FindWithTag ("Player");
	}

	// When the fire button is pressed
	// If the gun is active
	// Use raycasting to select the target
	// And use messages to call Deduct Points function
    void Update ()
	{
		//if ((Input.GetButton("Fire1") || Input.GetAxisRaw("FireRT") > 0) && Time.time > nextFire && ammo.CurrentAmmo > 0)		// If the fire button or right trigger is pressed
		if ((Input.GetButton("Fire1") || Input.GetAxisRaw("FireRT") > 0) && Time.time > nextFire && gc.GetComponent<ManageAmmo>().GetAmmo() > 0)// If the fire button or right trigger is pressed
        {
			// Stop the zombies being shot when the player is using crowbar/chainsaw, by checking is the gun active in the scene first
			if (player.GetComponent<WeaponSelect> ().GunActive ()) {
				nextFire = Time.time + fireRate;
				RaycastHit shot;

				if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out shot)) {
					targetDistance = shot.distance;                                                                         	// Set the target distance

					if (targetDistance < allowedRange) {                                                                      	// If the target distance is within range
						shot.transform.SendMessage ("DeductPoints", damageAmount, SendMessageOptions.DontRequireReceiver);   	// Can be called later on, with damage amount
					}
				}
			}
        }
    }
}