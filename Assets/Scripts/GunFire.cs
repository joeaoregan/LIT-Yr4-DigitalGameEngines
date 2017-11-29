using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {
    
    public float fireRate;
    public GlobalAmmo ammo;
    public AudioClip gunAudio;
    public AudioClip gunEmptyAudio;

    private float nextFire;
    private AudioSource audioSource;
    private Animation anim;
    
    // Survival Shooter
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

   // float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    //ParticleSystem gunParticles;
    LineRenderer gunLine;
    //AudioSource gunAudio;
   // Light gunLight;
   // float effectsDisplayTime = 0.2f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animation>();
    }
    
    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        //gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
       // gunLight = GetComponent<Light>();
    }
    
    //IEnumerator Start()
    private void Update()
    {
        if ((Input.GetButton("Fire1") || Input.GetAxisRaw("FireRT") > 0) && Time.time > nextFire) {
            nextFire = Time.time + fireRate;

            //yield return new WaitForSeconds(audioSource.clip.length);
            //audioSource.clip = gunshot;
            Shoot();
            anim.Play("GunShot");
           // anim.Play("CursUp");
            //anim.Play("DownCursAnim");
            //anim.Play("LeftCursAnim");
            //anim.Play("RightCursAnim");
        }
    }
    
    void Shoot()
    {
        // timer = 0f;

        if (ammo.CurrentAmmo > 0)
        {
            //audioSource.Play();
            ammo.CurrentAmmo -= 1;
            audioSource.clip = gunAudio;
            audioSource.volume = 1.0f;
        }
        else
        {
            audioSource.clip = gunEmptyAudio;
            audioSource.volume = 0.5f;
        }

        audioSource.Play();


        // gunLight.enabled = true;

        //gunParticles.Stop();
        //gunParticles.Play();

        //gunLine.enabled = true;
        //gunLine.SetPosition(0, transform.position);

        //shootRay.origin = transform.position;
        // shootRay.direction = transform.forward;
        /*
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {            
            //EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            //if (enemyHealth != null)
            //{
           //     enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            //}
            
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
        */
    }
}
