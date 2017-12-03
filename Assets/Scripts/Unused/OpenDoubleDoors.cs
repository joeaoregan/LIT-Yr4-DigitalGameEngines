/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoubleDoors : MonoBehaviour {

    //    private AudioSource doorSound;
    public Text TextDisplay;
    public float TheDistance;
    private PlayerCasting playerCasting;
   // PlayerCasting.DistanceFromTarget;
    public GameObject Door1;
    private AudioSource doorSound;
    private Animator door1Anim;

    private void Start()
    {
        TheDistance = playerCasting.getDistanceFromTarget();    // Initialise The Distance to Target
        doorSound = GetComponent<AudioSource>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerCasting = player.GetComponent<PlayerCasting>();
    }

    // Update is called once per frame
    void Update ()
    {
        TheDistance = playerCasting.getDistanceFromTarget();

        if (TheDistance <= 2.0f) OpenTheDoors();
    }

    private void OnMouseOver()
    {
        if (TheDistance <= 2.0f)
        {
            TextDisplay.GetComponent<Text>().text = "Press Action Button";
        }
    }

    private void OnMouseExit()
    {
        TextDisplay.GetComponent<Text> ().text = "";
    }

    public IEnumerator OpenTheDoors()
    {
        door1Anim = Door1.GetComponent<Animator>();
        door1Anim.speed = 1;
        door1Anim.Play("Door01");

        //Door1.GetComponent("Animator").enabled = true;              // open the doors
        //Door2.GetComponent("Animator").enabled = true;
        doorSound.Play();
        //Debug.Log("<color=green>Animator Enabled</color>");

        yield return new WaitForSeconds(1);                         // Wait one second (half way through the 2 second animation)

        //Door1.GetComponent("Animator").enabled = false;             // Stop when fully open
        door1Anim.speed = 0;
        //Door2.GetComponent("Animator").enabled = false;
        // Debug.Log("<color=red>Animator Disabled</color>");

        yield return new WaitForSeconds(5);                         // Wait 5 seconds

        //Door1.GetComponent("Animator").enabled = true;              // Then close the doors
        door1Anim.speed = 1;
        //Door2.GetComponent("Animator").enabled = true;
        doorSound.Play();
        //Debug.Log("<color=green>Animator Enabled</color>");

        yield return new WaitForSeconds(1);                         // Play the full closing half of animation

        //Door1.GetComponent("Animator").enabled = false;             // Then stop the door animations
        door1Anim.speed = 0;
        //Door2.GetComponent("Animator").enabled = false;
        //Debug.Log("<color=red>Animator Disabled</color>");
    }
}
*/