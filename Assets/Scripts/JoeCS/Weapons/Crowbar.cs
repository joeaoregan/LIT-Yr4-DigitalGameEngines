/*
 * Joe O'Regan
 * K00203642
 * 31/12/2017
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : MonoBehaviour {

	public float damageRate = 0.5f;							// How often a Player can fire
	public float hitRate = 1.3f;							// How often a Player can fire

	private float nextDamage;								// Sets the time the zombie will lose health next
	private float nextHit;									// Leave a gap the length of the animations between the next swing

	public int damagePerHit = 5;							// The damage inflicted by the gun

	public GameObject blood;								// Turn on the crowbar blood particles

	public AudioClip crowbarSwingClip1;						// Swing the crowbar
	public AudioClip crowbarSwingClip2;						// Swoosh sound

	private Animation anim;									// Gun animation
	private AudioSource audioSource;						// The audiosource for the gun

	private bool sawUp;										// Saw is in use
	private bool triggerPressed;							// Need to indicate the trigger is pressed, or sawUp is reset by the other buttons not being pressed
	private bool cutting;									// Attacking a zombie with the chainsaw (play different sound)
	private Collider zombieToCut;							// Use update to kill the zombie over a period of time while being cut by the chainsaw

    private void Start()
    {
		audioSource = GetComponent<AudioSource>();		// Initialise the audio source
        anim = GetComponent<Animation>();					// Initialise the animation
		triggerPressed = false;
		sawUp = false;
		zombieToCut = null;
		cutting = false;									// Chainsaw has not been triggered by a zombie yet
    }
        
    private void Update()
	{
		if(cutting) DamageZombie(zombieToCut);

		if ((Input.GetButton("Fire1") || Input.GetButtonDown("Fire1") || Input.GetAxisRaw("Fire1") > 0) && !sawUp)	// left mouse, button 1 gamepad, or gamepad right trigger
		if (Input.GetAxisRaw ("Fire1") > 0)
			triggerPressed = true;
		else
			triggerPressed = false;

		if ((Input.GetButton("Fire1") || Input.GetAxisRaw("FireRT") > 0) && !sawUp)	// left mouse, button 1 gamepad, or gamepad right trigger
		{	
			if (Time.time > nextHit) {
				nextHit = Time.time + hitRate;				

				//sawUp = true;
				int whichAnimation = Random.Range(1,4);

				// Random crowbar swing animation
				if (whichAnimation == 1)
					anim.Play("Crowbar4");	
				else if (whichAnimation == 2)
					anim.Play("Crowbar5");	
				else if (whichAnimation == 3)
					anim.Play("Crowbar6");	

				//Debug.Log ("Fire Button");

				//GetComponent<Animator>().SetTrigger("Start");

				// Random crowbar swing sound
				if(Random.Range(1,3) == 1)
					audioSource.clip = crowbarSwingClip1;
				else
					audioSource.clip = crowbarSwingClip2;				
				audioSource.Play();
			}
		}

		if (!Input.GetButton ("Fire1") && sawUp && !triggerPressed) {
				sawUp = false;

			//anim.Play ("ChainsawEnd");
			//GetComponent<Animator>().SetTrigger("End");
			//audioSource.clip = chainsawClip3;
			//audioSource.Play ();
		}

    }

    private void OnTriggerEnter(Collider other)
    {
		// Do chainsaw Audio & Damage
		if (other.gameObject.tag == "Zombie" && ((Input.GetButton("Fire1") || Input.GetButtonDown("Fire1") || Input.GetAxisRaw("FireRT") > 0))) {
			if (other.GetComponent<ZombieHealth> ().currentHealth > 0) {
				// Do Damage
				cutting = true;						// Cutting the zombie
				zombieToCut = other;				// Set collider

				blood.SetActive (true);

				//audioSource.clip = chainsawClip2;
				//audioSource.Play ();
			}
		}
	}
	private void OnTriggerExit(Collider other)
	{
		blood.SetActive (false);

		if (other.gameObject.tag == "Zombie" && ((Input.GetButton("Fire1") || Input.GetButtonDown("Fire1") || Input.GetAxisRaw("FireRT") > 0))) {
			cutting = false;					// Not cutting the zombie

			//audioSource.clip = chainsawClip1;
			//audioSource.Play ();
		}
	}

	private void DamageZombie(Collider other){
		if (Time.time > nextDamage) {
			nextDamage = Time.time + damageRate;	
			other.GetComponent<ZombieHealth> ().InjureZombie (damagePerHit);
		}
	}
}
