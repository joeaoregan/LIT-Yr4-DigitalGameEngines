// Joe O'Regan
// Level 2
// Pick up ammo, increase the ammo, animate the gun, and play reload sound to indicate ammo picked up

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2AmmoPickup : MonoBehaviour {

    //public GlobalAmmo ammo;											// Old method of accessing ammo value
    //public GameObject Player;											// Old method of accessing player

    public GunFire gun;

	private GameObject gc;												// Game controller object
	private GameObject player;											// Player object
	private AudioSource pickupAudio;
	    
    private void Start()
	{
		gc = GameObject.FindWithTag ("GammeController");
		player = GameObject.FindWithTag ("Player");
        pickupAudio = GetComponent<AudioSource>();
    }

    IEnumerator OnTriggerEnter (Collider Player) {
        if (Player.gameObject.tag == "Player")
        {
            Debug.Log("Player picked up Ammo");

			// Check the gun is active in the scene
			if(player.GetComponent<WeaponSelect>().GunActive())
            	gun.Reload();											// Do the reload animation

            //ammo.CurrentAmmo += 10;                                   // Increase the ammo
			gc.GetComponent<ManageAmmo>().AddAmmo(10);					// Increment the amount of ammo available
            pickupAudio.Play();                                         // Play pickup sound

            yield return new WaitForSeconds(pickupAudio.clip.length);   // Wait for the sound to play then
            //Destroy(this.gameObject);                                 // Destory the collectable object
			gameObject.SetActive(false);
        }
        else
            Debug.Log("Player can pick up ammo after collecting gun");		
    }
}
