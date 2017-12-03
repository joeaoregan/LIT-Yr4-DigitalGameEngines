using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {

    public GameObject flashObj;							// The image to display when the gun fires
    public ParticleSystem flashPart;					// Particles after firing gun
    public Light flashLight;							// Light after firing gun, this can be seen reflecting off other game objects

    public float fireRate = 0.25f;								// How often a Player can fire
    public GlobalAmmo ammo;								// The amount of ammo the Player has
    public AudioClip gunAudio;							// Sound effect for firing the gun
    public AudioClip gunEmptyAudio;						// Sound effect when the Player fires but is out of ammo
    public AudioClip reloadAudio;						// Sound effect when reloading the gun

    private float nextFire;								// Sets the time the weapon can fire next, fire rate
    private AudioSource audioSource;					// The audiosource for the gun
    private Animation anim;								// Gun animation
    
    // Survival Shooter
    public int damagePerShot = 20;						// The damage inflicted by the gun
 //   public float timeBetweenBullets = 0.15f;			// Time
//    public float range = 100f;

   // float timer;
   // Ray shootRay = new Ray();
   // RaycastHit shootHit;
    int shootableMask;									// Filter the layer the object is on, only selecting those on the shootable layer
    //ParticleSystem gunParticles;
   // LineRenderer gunLine;
    //AudioSource gunAudio;
   // Light gunLight;
   // float effectsDisplayTime = 0.2f;

    private void Start()
    {
        //flashLight.enabled = false;
		audioSource = GetComponent<AudioSource>();			// Initialise the audio source
        anim = GetComponent<Animation>();					// Initialise the animation
    }
    
    void Awake()
    {
        flashObj.SetActive(false);							// Deactivate the gun flash
        flashLight.enabled = false;							// Deactivate the light off from the gun firing
        shootableMask = LayerMask.GetMask("Shootable");
        //gunParticles = GetComponent<ParticleSystem>();
      //  gunLine = GetComponent<LineRenderer>();
       // gunLight = GetComponent<Light>();
    }
    
    //IEnumerator Start()
    private void Update()
    {
        if ((Input.GetButton("Fire1") || Input.GetAxisRaw("FireRT") > 0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;														// Set the time the next fire can occur to the current time + the fire rate
            
            //yield return new WaitForSeconds(audioSource.clip.length);
            //audioSource.clip = gunshot;	
            Shoot();
			anim.Play("GunShot");																	// Play the gun shot animation (Moves the gun trigger)
            //flash.SetActive(false);
            //flashObj.SetActive(true);
            //flash.Play();            
        }

        if (Input.GetButton("Reload")) Reload();    												// If reload button pressed reload
    }
    
    private IEnumerator MuzzleOff()
    {
        flashObj.SetActive(true);
        flashPart.Play();
        flashLight.enabled = true;
        Debug.Log("Muzzle Off Function particle");
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Muzzle Function 0.1f");
        flashLight.enabled = false;
        flashPart.Stop();
        flashObj.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ammo") anim.Play("GunShot");
        if (other.gameObject.tag == "Ammo") Debug.Log("Test 1");
        //Debug.Log("<color=red>Test1</color>");
     }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ammo") Debug.Log("Test 2");
        if (collision.gameObject.tag == "Ammo") anim.Play("Reload");
    }
    
    void Shoot()
    {
        // timer = 0f;

        Debug.Log("Light Off");

        if (ammo.CurrentAmmo > 0)
        {
            //audioSource.Play();
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


        //gunLight.enabled = true;
        //gunParticles.Stop();
        //gunParticles.Play();
        //gunLine.enabled = true;
        //gunLine.SetPosition(0, transform.position);

        //shootRay.origin = transform.position;
        // shootRay.direction = transform.forward;
        /*
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask)) {            
            //EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            //if (enemyHealth != null)
            //{
           //     enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            //}
            
            gunLine.SetPosition(1, shootHit.point);
        } else {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
        */
    }

    public void Reload() {
        anim.Play("Reload");

        audioSource.clip = reloadAudio;
        audioSource.Play();
    }
}
