
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDamage : MonoBehaviour {

    public float fireRate = 0.25f;
    public int damageAmount = 5;
    public float targetDistance;
    public float allowedRange = 15;
    private float nextFire;
    public GlobalAmmo ammo;

    // Update is called once per frame
    void Update ()
    {
        if ((Input.GetButton("Fire1") || Input.GetAxisRaw("FireRT") > 0) && Time.time > nextFire && ammo.CurrentAmmo > 0)                       // If the fire button or right trigger is pressed
        {
            nextFire = Time.time + fireRate;
            RaycastHit shot;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
            {
                targetDistance = shot.distance;                                                                         // Set the target distance

                if (targetDistance < allowedRange)                                                                      // If the target distance is within range
                {
                    shot.transform.SendMessage("DeductPoints", damageAmount, SendMessageOptions.DontRequireReceiver);   // Can be called later on, with damage amount
                }
            }
        }
    }
}