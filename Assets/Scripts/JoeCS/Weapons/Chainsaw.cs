/*
 * Joe O'Regan
 * K00203642
 * 30/12/2017
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour {
	
    public float damageRate = 0.7f;							// How often a Player can damage the zombies

	private float nextDamage;								// Sets the time to wait before taking more health from zombie
	public int damagePerCut = 5;							// The damage inflicted by the gun

	public GameObject blood;								// Turn on the chainsaw blood particles

	public AudioClip chainsawClip1;							// Chainsaw is up and running
	public AudioClip chainsawClip2;							// Chainsaw is cutting a zombie
	public AudioClip chainsawClip3;							// Chainsaw is powering down

	private Animation anim;									// Gun animation
	private AudioSource audioSource;						// The audiosource for the gun

	private bool sawUp;										// Saw is in use
	private bool triggerPressed;							// Need to indicate the trigger is pressed, or sawUp is reset by the other buttons not being pressed
	private bool cutting;									// Attacking a zombie with the chainsaw (play different sound)
	private Collider zombieToCut;							// Use update to kill the zombie over a period of time while being cut by the chainsaw

    private void Start()
    {
		audioSource = GetComponent<AudioSource>();			// Initialise the audio source
        anim = GetComponent<Animation>();					// Initialise the animation
		triggerPressed = false;
		sawUp = false;
		zombieToCut = null;
		cutting = false;									// Chainsaw has not been triggered by a zombie yet
    }
        
    private void Update()
	{
		if(cutting) DamageZombie(zombieToCut);

		//if ((Input.GetButton("Fire1") || Input.GetButtonDown("Fire1") || Input.GetAxisRaw("Fire1") > 0) && !sawUp)	// left mouse, button 1 gamepad, or gamepad right trigger
		if (Input.GetAxisRaw ("Fire1") > 0)
			triggerPressed = true;
		else
			triggerPressed = false;

		if ((Input.GetButton("Fire1") || Input.GetAxisRaw("FireRT") > 0) && !sawUp)	// left mouse, button 1 gamepad, or gamepad right trigger
		//if ((Input.GetAxis("FireRT") > 0 && !sawUp))	// left mouse, button 1 gamepad, or gamepad right trigger
		{	
			sawUp = true;
			//firebutton = true;
			//nextFire = Time.time + fireRate;														// Set the time the next fire can occur to the current time + the fire rate

			//Shoot();
			//StartCoroutine(SawAnimation());
			//anim.Play("Chainsaw2");	

			GetComponent<Animator>().SetTrigger("Start");

			audioSource.clip = chainsawClip1;
			audioSource.Play();

		}
		//if (Input.GetButtonUp ("Fire1") && sawUp) sawUp = false;			
		//if (Input.GetAxisRaw ("FireRT") == 0) sawUp = false;
				//if (Input.GetButtonUp ("Fire1") || Input.GetAxisRaw ("FireRT") == 0) // moves up and down
		//if (Input.GetButtonUp ("Fire1") || !(Input.GetAxisRaw ("FireRT") > 0)) {
		//if (Input.GetButtonUp ("Fire1") || (!Input.GetButtonDown("Fire1") && sawUp)|| (!(Input.GetAxisRaw ("FireRT") > 0) && sawUp)) {
		//if ((Input.GetButtonUp ("Fire1") && sawUp) || (!Input.GetButton("Fire1") && sawUp) || (!(Input.GetAxisRaw ("FireRT") > 0) && sawUp)) {
			//if ((Input.GetAxisRaw ("FireRT") == 0)) 

		if (!Input.GetButton ("Fire1") && sawUp && !triggerPressed) {
				sawUp = false;

			//anim.Play ("ChainsawEnd");
			GetComponent<Animator>().SetTrigger("End");
			audioSource.clip = chainsawClip3;
			audioSource.Play ();
		}

        //if (Input.GetButton("Reload")) Reload();    												// If reload button pressed reload
    }

	IEnumerator SawAnimation(){
		anim.Play("Chainsaw1StartLecacy");	
		//yield return new WaitForSeconds (anim.clip.length);
		yield return new WaitForSeconds (1);
		anim.Play ("Chainsaw2");
	}

    private void OnTriggerEnter(Collider other)
    {
		// Do chainsaw Audio & Damage
		if (other != null) {
			if (other.gameObject.tag == "Zombie" && other.GetComponent<ZombieHealth> ().currentHealth > 0 && ((Input.GetButton ("Fire1") || Input.GetButtonDown ("Fire1") || Input.GetAxisRaw ("FireRT") > 0))) {
				//if (other.GetComponent<ZombieHealth> ().currentHealth > 0) {
				// Do Damage
				cutting = true;						// Cutting the zombie
				zombieToCut = other;				// Set collider

				//DamageZombie(other);

				blood.SetActive (true);

				//Debug.Log ("cut");
				//audioSource.pitch = 2;
				audioSource.clip = chainsawClip2;
				audioSource.Play ();
				//}
			}
		}
	}
	private void OnTriggerExit(Collider other)
	{
		blood.SetActive (false);

		if (other.gameObject.tag == "Zombie" && ((Input.GetButton("Fire1") || Input.GetButtonDown("Fire1") || Input.GetAxisRaw("FireRT") > 0))) {
			cutting = false;					// Not cutting the zombie

			//audioSource.pitch = 1;
			audioSource.clip = chainsawClip1;
			audioSource.Play ();
		}
	}

	private void DamageZombie(Collider other){
		if (Time.time > nextDamage) {
			nextDamage = Time.time + damageRate;	
			other.GetComponent<ZombieHealth> ().InjureZombie (damagePerCut);
		}
	}


	/*
    private void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.tag == "Zombie")
			blood.SetActive (true);
    }
    */
}
