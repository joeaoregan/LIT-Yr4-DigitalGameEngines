using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour {

    public GlobalAmmo ammo;
    private AudioSource pickupAudio;
    
    private void Start()
    {
        pickupAudio = GetComponent<AudioSource>();
    }

    IEnumerator OnTriggerEnter (Collider Player) {
        if (Player.gameObject.tag == "Player") Debug.Log("Player picked up Ammo");
        
        ammo.CurrentAmmo += 10;                                     // Increase the ammo
        pickupAudio.Play();                                         // Play pickup sound

        yield return new WaitForSeconds(pickupAudio.clip.length);   // Wait for the sound to play then
        Destroy(this.gameObject);                                   // Destory the collectable object
	}
}
