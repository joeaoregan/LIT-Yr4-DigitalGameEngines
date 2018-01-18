// Joe O'Regan
// Level 1
// Objective 3
// Destroy the targets

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // To use UI components

public class DestroyTargetScript : MonoBehaviour {

    public int enemyHealth = 15;                			// Default enemy health value set to 10
    public GameObject targetToDestroy;          			// Destroy the entire object after hitting bullseye twice

	public ManageTargets target;

	public Slider healthBar;

	public TargetScoreboard targetScoreboard;
	bool destroyed;
    
    void Update()    {
        if (enemyHealth <= 0 && ! destroyed)      			// If the enemies health has run out
        {
            //Destroy(gameObject);              			// Destroy the game object the script is attached to (Bullseye)
            //Destroy(targetToDestroy);           			// Destroy the parent target object
			StartCoroutine(WaitForScoreAnimToFinish());		// Wait for the score animation to finish displaying
			if (targetToDestroy.gameObject.tag == "Target")	// If the object to be destroyed is a target
				target.IncrementTargets ();					// Increment the number of targets
			destroyed = true;
        }
    }

	IEnumerator WaitForScoreAnimToFinish(){
		yield return new WaitForSeconds (1);
		Destroy(targetToDestroy);           				// Destroy the parent target object
	}
    
    void DeductPoints(int DamageAmount)
    {
        enemyHealth -= DamageAmount;            			// Decrement enemy health
		healthBar.value = enemyHealth;
		targetScoreboard.IncrementHits ();
    }
}

