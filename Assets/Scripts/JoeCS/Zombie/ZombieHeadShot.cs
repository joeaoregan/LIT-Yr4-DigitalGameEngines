using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHeadShot : MonoBehaviour {

	public AudioSource audio;
	public AudioClip shotFX;

    public int zombieHealth = 5;                			// Default enemy health value set to 15

	public ManageZombies zombieCount;
	public GameObject bloodSplatter;
	public GameObject destroyZombie;						// Needed for separate head shots

	public Text actionText;									// Canvas action text
    
	/*
    void Update()    {
		if (zombieHealth <= 0)                   			// If the enemies health has run out
		{
			//Destroy(gameObject);              			// Destroy the game object the script is attached to
			Destroy(destroyZombie);              			// Destroy the game object specified by destroyZombie

			//if (gameObject.tag == "Zombie")				// If the object to be destroyed is a target
				zombieCount.incrementZombies ();			// Increment the number of zombies killed
        }
    }
    */

    void DeductPoints(int DamageAmount)
    {
		zombieHealth -= DamageAmount;            			// Decrement enemy health
		audio.clip = shotFX;								// Load the effect into the audio source
		audio.Play();										// Play the effect
		StartCoroutine(BloodSplatter());
    }

	/*
	 	1 headshot needed to kill Zombie
 	*/
	IEnumerator BloodSplatter(){
		bloodSplatter.SetActive (true);
		//yield return new WaitForSeconds (0.4f);			// Display the particle for the specified time
		//bloodSplatter.SetActive (false);					// Turn it off (no need really)
		zombieCount.incrementZombies ();					// Increment the number of zombies killed
		actionText.GetComponent<Text> ().text = "Headshot 50";	// Display headshot message
		yield return new WaitForSeconds (2);				// Show on screen for specified time
		actionText.GetComponent<Text> ().text = "";			// Then clear the message
		Destroy(destroyZombie);              				// Destroy the game object specified by destroyZombie
	}
}

