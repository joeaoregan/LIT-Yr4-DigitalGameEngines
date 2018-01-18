using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {

    public GameObject flashObj;							// The image to display when the gun fires
    public ParticleSystem flashPart;					// Particles after firing gun
    public Light flashLight;							// Light after firing gun, this can be seen reflecting off other game objects

    public float fireRate = 0.25f;						// How often a Player can fire
    public GlobalAmmo ammo;								// The amount of ammo the Player has
    public AudioClip gunAudio;							// Sound effect for firing the gun
    public AudioClip gunEmptyAudio;						// Sound effect when the Player fires but is out of ammo
    public AudioClip reloadAudio;						// Sound effect when reloading the gun

    private float nextFire;								// Sets the time the weapon can fire next, fire rate
    private AudioSource audioSource;					// The audiosource for the gun
    private Animation anim;								// Gun animation
    
    public int damagePerShot = 20;						// The damage inflicted by the gun

    //int shootableMask;								// Filter the layer the object is on, only selecting those on the shootable layer

    private void Start()
    {
		audioSource = GetComponent<AudioSource>();		// Initialise the audio source
        anim = GetComponent<Animation>();				// Initialise the animation
    }
    
    void Awake()
    {
        flashObj.SetActive(false);						// Deactivate the gun flash
        flashLight.enabled = false;						// Deactivate the light off from the gun firing
        //shootableMask = LayerMask.GetMask("Shootable");
    }
    
    private void Update()
    {
		if ((Input.GetButton("Fire1") || Input.GetButtonDown("Fire1") || Input.GetAxisRaw("FireRT") > 0) && Time.time > nextFire)	// left mouse, button 1 gamepad, or gamepad right trigger
        {
            nextFire = Time.time + fireRate;														// Set the time the next fire can occur to the current time + the fire rate
            
            Shoot();
			anim.Play("GunShot");	
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

        if (ammo.CurrentAmmo > 0)
        {
            ammo.CurrentAmmo -= 1;
            audioSource.clip = gunAudio;
            audioSource.volume = 1.0f;

            StartCoroutine(MuzzleOff());
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
}
