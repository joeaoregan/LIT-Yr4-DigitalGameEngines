using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour {

	public AudioSource audio;
	public AudioClip shotFX;

    public int zombieHealth = 15;                		// Default enemy health value set to 15

	public ManageZombies zombieCount;
	public GameObject bloodSplatter;
	//public GameObject destroyZombie;					// Needed for separate head shots
   /* 
    void Update()    {
		if (zombieHealth <= 0)                   		// If the enemies health has run out
		{
			Destroy(gameObject);              			// Destroy the game object the script is attached to
			//Destroy(destroyZombie);              		// Destroy the game object specified by destroyZombie - separate headshot script
			//if (gameObject.tag == "Zombie")			// If the object to be destroyed is a target
			zombieCount.incrementZombies ();			// Increment the number of zombies killed
        }
    }
    */
    void DeductPoints(int DamageAmount)
    {
		zombieHealth -= DamageAmount;            		// Decrement enemy health
		audio.clip = shotFX;							// Load the effect into the audio source
		audio.Play();									// Play the effect
		StartCoroutine(BloodSplatter());
    }

	IEnumerator BloodSplatter(){
		bloodSplatter.SetActive (true);					// Turn on the blood particles
		yield return new WaitForSeconds (0.5f);			// Show them for half a second
		bloodSplatter.SetActive (false);				// Turn them off again

		if (zombieHealth <= 0)                   		// If the enemies health has run out
		{
			Destroy(gameObject);              			// Destroy the game object the script is attached to
			zombieCount.incrementZombies ();			// Increment the number of zombies killed
		}
	}
}

