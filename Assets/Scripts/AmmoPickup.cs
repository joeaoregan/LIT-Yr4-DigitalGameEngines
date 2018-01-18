using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour {

    public GlobalAmmo ammo;
    //public GameObject Player;

    //public GameObject hasGun;

    public GunFire gun;

	//public ObjectiveCounter numObjectives;								// Check the number of complete objective
	//public GameObject getAmmoObjective;									// Mark the get ammo objective as complete

	private AudioSource pickupAudio;
	private GameObject player;

    private void Start()
    {
        pickupAudio = GetComponent<AudioSource>();
		player = GameObject.FindWithTag ("Player");
    }

	IEnumerator OnTriggerEnter (Collider Player) {
		//if (Player.gameObject.tag == "Player" && hasGun.activeInHierarchy)
		if (Player.gameObject.tag == "Player" && player.GetComponent<WeaponSelect>().GetHasGun())
        {
            Debug.Log("Player picked up Ammo");

			// Check the gun is active in the scene before calling the Reload() function
			if (Player.GetComponent<WeaponSelect>().GunActive()) 
				gun.Reload();

            ammo.CurrentAmmo += 10;                                     // Increase the ammo
            pickupAudio.Play();                                         // Play pickup sound

            yield return new WaitForSeconds(pickupAudio.clip.length);   // Wait for the sound to play then
            //Destroy(this.gameObject);                                 // Destory the collectable object
			gameObject.SetActive(false);
        }
        else
            Debug.Log("Player can pick up ammo after collecting gun");

		//if (numObjectives.getObjectiveCount () == 1) {					// If we are looking to complete the 2nd objective (pick up ammo)
		//	getAmmoObjective.SetActive (true);							// Mark the get ammo objective as complete
		//}
    }
}
