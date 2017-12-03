using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour {

    public int zombieHealth = 15;                			// Default enemy health value set to 10
   // public GameObject targetToDestroy;          			// Destroy the entire object after hitting bullseye twice

	public ManageZombies zombieCount;
    
    void Update()    {
		if (zombieHealth <= 0)                   			// If the enemies health has run out
        {
            Destroy(gameObject);              			// Destroy the game object the script is attached to (Bullseye)
            //Destroy(targetToDestroy);           			// Destroy the parent target object

			//if (gameObject.tag == "Zombie")	// If the object to be destroyed is a target
				zombieCount.incrementZombies ();					// Increment the number of targets
        }
    }
    
    void DeductPoints(int DamageAmount)
    {
		zombieHealth -= DamageAmount;            			// Decrement enemy health
    }
}

