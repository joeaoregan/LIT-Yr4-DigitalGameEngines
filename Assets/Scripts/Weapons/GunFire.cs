// Joe O'Regan
// Script to fire the gun
// Modified from original Jimmy Vegas FPS & Unity Survival Shooter tutorials
// Supports Keyboard, Mouse, and Gamepad (Tested on Xbox One S controller)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {

    public GameObject flashObj;							// The image to display when the gun fires
    public ParticleSystem flashPart;					// Particles after firing gun
    public Light flashLight;							// Light after firing gun, this can be seen reflecting off other game objects

	public float fireRate = 0.25f;						// How often a Player can fire
	public int damagePerShot = 20;						// The damage inflicted by the gun
    //public GlobalAmmo ammo;							// The amount of ammo the Player has
    public AudioClip gunAudio;							// Sound effect for firing the gun
    public AudioClip gunEmptyAudio;						// Sound effect when the Player fires but is out of ammo
    public AudioClip reloadAudio;						// Sound effect when reloading the gun

    private float nextFire;								// Sets the time the weapon can fire next, fire rate

    private AudioSource audioSource;					// The audiosource for the gun
    private Animation anim;								// Gun animation    
	private GameObject gc;								// Get the game controller

	//private GameObject gc;
    //int shootableMask;								// Filter the layer the object is on, only selecting those on the shootable layer

	private int TargetShots;

	//public ObjectiveCounter objectiveCounter;			// Moved to game controller

    private void Start()
	{
		gc = GameObject.FindWithTag ("GameController");	// Locate game controller
		audioSource = GetComponent<AudioSource>();		// Initialise the audio source
        anim = GetComponent<Animation>();				// Initialise the animation
    }
    
    void Awake()
	{
		//gc = GameObject.FindWithTag ("GameController");// Get the game controller
        flashObj.SetActive(false);						// Deactivate the gun flash
        flashLight.enabled = false;						// Deactivate the light off from the gun firing
        //shootableMask = LayerMask.GetMask("Shootable");
    }
    
    private void Update()
	{
		//if (Input.GetAxisRaw ("FireLT") > 0)
		//	Debug.Log ("Run");

		//if (Input.GetAxisRaw ("FireRT") > 0)
		//	Debug.Log ("Fire");

		if ((Input.GetButton("Fire1") || Input.GetButtonDown("Fire1") || Input.GetAxisRaw("FireRT") > 0) && Time.time > nextFire)	// left mouse, button 1 gamepad, or gamepad right trigger
        {
            nextFire = Time.time + fireRate;														// Set the time the next fire can occur to the current time + the fire rate
            
            Shoot();
			anim.Play("GunShot");	

			// test zombie pause
			//bool zombiesPaused = gc.GetComponent<ManageZombies> ().ZombiesPaused ();			// Are the zombies paused from moving
			//if (!zombiesPaused) anim.SetTrigger ("Walk");										// Set to idle animation loop

			//if (!zombiesPaused)
			//	gc.GetComponent<ManageZombies> ().PauseZombies (!zombiesPaused);
			//else 
				//gc.GetComponent<ManageZombies> ().PauseZombies (!zombiesPaused);

			//GameObject.FindWithTag ("Player").GetComponent<Ready> ().SetReady (true);
        }

        if (Input.GetButton("Reload")) Reload();    												// If reload button pressed reload
    }
    
    private IEnumerator MuzzleOff()
    {
        flashObj.SetActive(true);
        flashPart.Play();
        flashLight.enabled = true;
        Debug.Log("Shot Fired: Muzzle Off Function particle");
        yield return new WaitForSeconds(0.1f);
        //Debug.Log("Muzzle Function 0.1f");
        flashLight.enabled = false;
        flashPart.Stop();
        flashObj.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ammo") anim.Play("GunShot");
        //if (other.gameObject.tag == "Ammo") Debug.Log("Test 1");
     }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Ammo") Debug.Log("Test 2");
        if (collision.gameObject.tag == "Ammo") anim.Play("Reload");	// When the player walks over ammo, play animation
    }
    
    void Shoot()
    {
        //Debug.Log("Light Off");

       // if (ammo.CurrentAmmo > 0)
      //  {
      //      ammo.CurrentAmmo -= 1;

		if(	gc.GetComponent<ManageAmmo> ().GetAmmo() > 0){		// Returns the value of currentAmmo, the amount of ammo the player has
			gc.GetComponent<ManageAmmo> ().FireShot ();			// Deducts 1 from ammo
            audioSource.clip = gunAudio;
            audioSource.volume = 1.0f;

            StartCoroutine(MuzzleOff());

			TargetPracticeShots();
        }
        else
        {
            audioSource.clip = gunEmptyAudio;
            audioSource.volume = 0.5f;
        }

        audioSource.Play();
    }

    public void Reload() {
        anim.Play("Reload");

        audioSource.clip = reloadAudio;
        audioSource.Play();
    }

	private void TargetPracticeShots(){
		if (gc.GetComponent<ManageObjectives>().getObjectiveCount () < 3)
			TargetShots++;
	}

	public int ShotsFired(){
		return TargetShots;
	}
}
