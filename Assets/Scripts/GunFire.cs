using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {

    public GameObject flashObj;
    public ParticleSystem flashPart;
    public Light flashLight;

    public float fireRate;
    public GlobalAmmo ammo;
    public AudioClip gunAudio;
    public AudioClip gunEmptyAudio;
    public AudioClip reloadAudio;

    private float nextFire;
    private AudioSource audioSource;
    private Animation anim;
    
    // Survival Shooter
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

   // float timer;
   // Ray shootRay = new Ray();
   // RaycastHit shootHit;
    int shootableMask;
    //ParticleSystem gunParticles;
   // LineRenderer gunLine;
    //AudioSource gunAudio;
   // Light gunLight;
   // float effectsDisplayTime = 0.2f;

    private void Start()
    {
        //flashLight.enabled = false;
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animation>();
    }
    
    void Awake()
    {
        flashObj.SetActive(false);
        flashLight.enabled = false;
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
            nextFire = Time.time + fireRate;
            
            //yield return new WaitForSeconds(audioSource.clip.length);
            //audioSource.clip = gunshot;
            Shoot();
            anim.Play("GunShot");
            //flash.SetActive(false);
            //flashObj.SetActive(true);
            //flash.Play();            
        }

        if (Input.GetButton("Reload")) Reload();    // If reload button pressed reload
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
