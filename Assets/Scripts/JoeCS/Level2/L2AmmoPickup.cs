using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2AmmoPickup : MonoBehaviour {

    public GlobalAmmo ammo;
    //public GameObject Player;

    private AudioSource pickupAudio;
    public GunFire gun;

	GameObject player;
	    
    private void Start()
    {
        pickupAudio = GetComponent<AudioSource>();
		player = GameObject.FindWithTag ("Player");
    }

    IEnumerator OnTriggerEnter (Collider Player) {
        if (Player.gameObject.tag == "Player")
        {
            Debug.Log("Player picked up Ammo");

			// Check the gun is active in the scene
			if(player.GetComponent<WeaponSelect>().GunActive())
            	gun.Reload();

            ammo.CurrentAmmo += 10;                                     // Increase the ammo
            pickupAudio.Play();                                         // Play pickup sound

            yield return new WaitForSeconds(pickupAudio.clip.length);   // Wait for the sound to play then
            //Destroy(this.gameObject);                                 // Destory the collectable object
			gameObject.SetActive(false);
        }
        else
            Debug.Log("Player can pick up ammo after collecting gun");		
    }
}
