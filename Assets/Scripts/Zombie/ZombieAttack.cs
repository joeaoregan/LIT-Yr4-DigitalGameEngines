using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f; 												// Amount of time between each attack
    public int attackDamage = 10;           												// Damage inflicted

 	

	// Audio
	public AudioClip snarl1;
	public AudioClip snarl2;

	private AudioSource zomAudio;

	// Attack
	private bool playerInRange;
	private bool scream;
	private float timer;																			// Time the attacks

	private Animator anim;
	private GameObject player;                      												// The enemy needs a reference to the player to attack them
	private PlayerHealth playerHealth;              												// Enemy has a reference to the Player health script so it can damage the Player
	private ZombieHealth zombieHealth;              												// Zombie health script reference

    void Awake ()
	{
		//Debug.Log("Find Player Tag");
        player = GameObject.FindGameObjectWithTag ("Player");   							// Locate the Player
        playerHealth = player.GetComponent <PlayerHealth> ();   							// Get the health script component of the Player

		zomAudio = GetComponent<AudioSource> ();
		zombieHealth = GetComponent<ZombieHealth>();             							// Get component script Zombie health
        anim = GetComponent <Animator> ();                     								// Reference to animator component
		scream = false;
    }


    void OnTriggerEnter (Collider other)                        							// Called whenever anything goes into a trigger
    {
        if(other.gameObject == player)                          							// Make sure it is the player we are attacking
		{
			Debug.Log("Health " + playerHealth.currentHealth);
            playerInRange = true;                               							// Player is in range for Zombie to attack         
        }
    }


    void OnTriggerExit (Collider other)                                                     // Something was in the trigger and has now gone away
    {
		if(other.gameObject == player && zombieHealth.currentHealth > 0)          			// If the object leaving the collider is the Player                
		{
			//Debug.Log("Player Out Of Range");
            playerInRange = false;                                                          // Player is no longer in range
			anim.SetTrigger ("PlayerOutOfRange");											// Player has moved out of attacking range
			StartCoroutine(ZombieScream());
        }
    }

	IEnumerator ZombieScream(){
		Debug.Log("<color=orange>Zombie Screaming</color>");

		scream = true;
		yield return new WaitForSeconds (2);
		scream = false;
	}

	// Stop the zombie following the player if it is screaming (because it just looks daft)
	public bool IsScreaming(){
		return scream;
	}


    void Update ()
    {
        timer += Time.deltaTime;                                                            // how much time has passed

        if(timer >= timeBetweenAttacks && playerInRange && zombieHealth.currentHealth > 0)   // If time is long enough and player is in range attack
        {
            Attack ();                                                                      // Call attack() function
        }

		if(playerHealth.currentHealth <= 0)													// If the players health runs out
        {	
            //anim.SetTrigger ("PlayerDead");												// Trigger the dying animation
			Debug.Log("Player has died");
        }
    }


    void Attack ()
    {
        timer = 0f;																			// Reset the timer

		if(playerHealth.currentHealth > 0)                                                  // If player is alive
		{
			// Random attack sound effect
			if (Random.Range (1, 3) == 1)
				zomAudio.clip = snarl1;
			else
				zomAudio.clip = snarl2;
			
			zomAudio.Play ();

			// Random animation trigger
			if (Random.Range (1, 3) == 1)
				anim.SetTrigger ("PlayerInRange1");											// Trigger the attack animation
			else
				anim.SetTrigger ("PlayerInRange2");											// Trigger the bite neck attack animation
			//Debug.Log ("Attack()");
            playerHealth.TakeDamage (attackDamage);                                         // Take some of the players health
        }
    }
}
