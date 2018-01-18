// Joe O'Regan
// All Levels
// Add to the amount of ammo available to the player
// When player triggers the ammo pickup collider

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmmoPickup : MonoBehaviour {

    //public GlobalAmmo ammo;
    //public GameObject Player;

    //public GameObject hasGun;

	public int ammoToAdd = 10;
    public GunFire gun;

	//public ObjectiveCounter numObjectives;								// Check the number of complete objective
	//public GameObject getAmmoObjective;									// Mark the get ammo objective as complete

	private AudioSource pickupAudio;										// Audio Source component
	private GameObject player;												// Player
	private GameObject gc;													// Game Controller

    private void Start()
	{
		gc = GameObject.FindWithTag ("GameController");						// Find game controller using its tag
		player = GameObject.FindWithTag ("Player");							// Find player using tag value
		pickupAudio = GetComponent<AudioSource>();
    }

	IEnumerator OnTriggerEnter (Collider Player) {
		// if its level 1 and the objective isn't already marked complete, and the player has the gun
		if (SceneManager.GetActiveScene().buildIndex == 3 && !gc.GetComponent<ManageObjectives>().GetObjective2Complete() && gc.GetComponent<ManageObjectives>().GetObjective1Complete())
			gc.GetComponent<ManageObjectives>().SetObjective2Complete(true);// Mark objective 2 complete and increment completed objectives

		//if (Player.gameObject.tag == "Player" && hasGun.activeInHierarchy)
		if (Player.gameObject.tag == "Player" && player.GetComponent<WeaponSelect>().GetHasGun())
        {
            Debug.Log("Player picked up Ammo");

			// Check the gun is active in the scene before calling the Reload() function
			if (Player.GetComponent<WeaponSelect>().GunActive()) 
				gun.Reload();

            //ammo.CurrentAmmo += 10;                                   // Increase the ammo
			//ammo.AddAmmo(10);											// Add 10 to ammo and animate text
			gc.GetComponent<ManageAmmo>().AddAmmo(ammoToAdd);			// Add 10 to ammo with animated text on HUD panel
            pickupAudio.Play();                                         // Play pickup sound

            yield return new WaitForSeconds(pickupAudio.clip.length);   // Wait for the sound to play then
            //Destroy(this.gameObject);                                 // Destory the collectable object
			gameObject.SetActive(false);
        }
        else
            Debug.Log("Player can pick up ammo after collecting gun");

		//if (numObjectives.getObjectiveCount () == 1) {				// If we are looking to complete the 2nd objective (pick up ammo)
		//	getAmmoObjective.SetActive (true);							// Mark the get ammo objective as complete
		//}
    }
}
