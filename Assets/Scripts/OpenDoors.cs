// Script to open doors, replaces javascript version

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoors : MonoBehaviour {
	
    //public float TheDistance;
    //public GameObject Door1;
	//private PlayerCasting playerCasting;
	//private Animator door1Anim;


	public float distanceTo;													// Raycast distance to object

	public GameObject door1;
	public GameObject door2;
	public GameObject buttonOn;
	public GameObject buttonOff;

	private GameObject mainCam;													// Get the first person controller camera
	private Text infoMsg;														// Replaces actionText as information/action text in gam
	private AudioSource doorSound;

	private Animation anim;														// Door animation

    private void Start()
	{
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();	// Get the action/information text object
		anim = GetComponent<Animation>();										// Initialise the animation
		doorSound = GetComponent<AudioSource>();
		//TheDistance = playerCasting.getDistanceFromTarget();    				// Initialise The Distance to Target
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //playerCasting = player.GetComponent<PlayerCasting>();
    }

    void Update ()
	{
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();
        //if (TheDistance <= 2.0f) OpenTheDoors();
    }

    private void OnMouseOver()
    {
		if (distanceTo <= 2.0f)
        {
			infoMsg.text = "Press Action Button To Open";
			StartCoroutine ("ClearText");
		}

		if (Input.GetButtonDown("Action")) {
			// Debug.Log("<color=red>Action Button Pressed</color>");
			if (distanceTo <= 2) {                   	 						// If the distance to the object is less than 2
				//StartCoroutine(OpenTheDoors());                              	// Call the open door function
				StartCoroutine(OpenTheDoors2());                              	// Call the open door function
			}
		}
    }

    private void OnMouseExit()
    {
		infoMsg.text = "";
    }

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2.0f);
		infoMsg.text = "";
	}

	public IEnumerator OpenTheDoors()
	{
		// Open
		anim.Play("Door1Open");	
		//anim.Play("Door2Open");	

		doorSound.Play();
		buttonOn.SetActive(true);                           	// Show the green button
		buttonOff.SetActive(false);                        	 	// Hide the red button
		//Debug.Log("<color=green>Animator Enabled</color>");

		yield return new WaitForSeconds(6);                     // Wait 5 seconds

		// Close
		anim.Play("Door1Close");	
		//anim.Play("Door2Close");	
		doorSound.Play();
		//Debug.Log("<color=green>Animator Enabled</color>");

		yield return new WaitForSeconds(1);                     // Play the full closing half of animation

		// Stop
		Debug.Log("<color=red>Door Animator Disabled</color>");

		buttonOn.SetActive(false);                          	// Hide the green button
		buttonOff.SetActive(true);                          	// Show the red button
	}


	public IEnumerator OpenTheDoors2()
	{
		// Open
		anim.Play("Door1Open");	
		anim.Play("Door2Open");	

		doorSound.Play();
		buttonOn.SetActive(true);                           	// Show the green button
		buttonOff.SetActive(false);                        	 	// Hide the red button

		door1.GetComponent<Animator> ().enabled = true;      	// Then close the doors
		door2.GetComponent<Animator> ().enabled = true;
		//Debug.Log("<color=green>Animator Enabled</color>");

		yield return new WaitForSeconds(1);                     // Wait one second (half way through the 2 second animation)


		// Stop
		door1.GetComponent<Animator> ().enabled = false;     	// Stop when fully open
		door2.GetComponent<Animator> ().enabled = false;
		// Debug.Log("<color=red>Animator Disabled</color>");

		yield return new WaitForSeconds(6);                     // Wait 5 seconds

		// Close
		door1.GetComponent<Animator> ().enabled = true;      	// Then close the doors
		door2.GetComponent<Animator> ().enabled = true;
		doorSound.Play();
		//Debug.Log("<color=green>Animator Enabled</color>");

		yield return new WaitForSeconds(1);                     // Play the full closing half of animation

		// Stop
		door1.GetComponent<Animator> ().enabled = false;     	// Then stop the door animations
		door2.GetComponent<Animator> ().enabled = false;
		Debug.Log("<color=red>Door Animator Disabled</color>");

		buttonOn.SetActive(false);                          	// Hide the green button
		buttonOff.SetActive(true);                          	// Show the red button
	}


	public IEnumerator OpenTheDoorsOld()
	{/*
        //door1Anim = Door1.GetComponent<Animator>();
		//door1Anim.speed = 1;
		//door1Anim.Play("Door01");

		//Door1.GetComponent("Animator").enabled = true;        // open the doors
		//Door2.GetComponent("Animator").enabled = true;
		//doorSound.Play();
		//Debug.Log("<color=green>Animator Enabled</color>");
		yield return new WaitForSeconds(1);                     // Wait one second (half way through the 2 second animation)

		//Door1.GetComponent("Animator").enabled = false;       // Stop when fully open
		door1Anim.speed = 0;
		//Door2.GetComponent("Animator").enabled = false;
		// Debug.Log("<color=red>Animator Disabled</color>");
		yield return new WaitForSeconds(5);                     // Wait 5 seconds
		//Door1.GetComponent("Animator").enabled = true;        // Then close the doors
		door1Anim.speed = 1;
		//Door2.GetComponent("Animator").enabled = true;
		doorSound.Play();
		//Debug.Log("<color=green>Animator Enabled</color>");

		yield return new WaitForSeconds(1);                     // Play the full closing half of animation

		//Door1.GetComponent("Animator").enabled = false;       // Then stop the door animations
		door1Anim.speed = 0;
		//Door2.GetComponent("Animator").enabled = false;
		//Debug.Log("<color=red>Animator Disabled</color>");
		*/

		/*
		// Open
		door1.GetComponent<Animator> ().enabled = true;
		door2.GetComponent<Animator> ().enabled = true;

		doorSound.Play();
		buttonOn.SetActive(true);                           	// Show the green button
		buttonOff.SetActive(false);                        	 	// Hide the red button
		//Debug.Log("<color=green>Animator Enabled</color>");

		yield return new WaitForSeconds(1);                     // Wait one second (half way through the 2 second animation)


		// Stop
		door1.GetComponent<Animator> ().enabled = false;     	// Stop when fully open
		door2.GetComponent<Animator> ().enabled = false;
		// Debug.Log("<color=red>Animator Disabled</color>");

		yield return new WaitForSeconds(5);                     // Wait 5 seconds

		// Close
		door1.GetComponent<Animator> ().enabled = true;      	// Then close the doors
		door2.GetComponent<Animator> ().enabled = true;
		doorSound.Play();
		//Debug.Log("<color=green>Animator Enabled</color>");

		yield return new WaitForSeconds(1);                     // Play the full closing half of animation

		// Stop
		door1.GetComponent<Animator> ().enabled = false;     	// Then stop the door animations
		door2.GetComponent<Animator> ().enabled = false;
		Debug.Log("<color=red>Door Animator Disabled</color>");

		buttonOn.SetActive(false);                          	// Hide the green button
		buttonOff.SetActive(true);                          	// Show the red button
		*/


		// Open
		anim.Play("Door1Open");	
		anim.Play("Door2Open");	

		doorSound.Play();
		buttonOn.SetActive(true);                           	// Show the green button
		buttonOff.SetActive(false);                        	 	// Hide the red button
		//Debug.Log("<color=green>Animator Enabled</color>");

		//yield return new WaitForSeconds(1);                     // Wait one second (half way through the 2 second animation)


		// Stop
		//door1.GetComponent<Animator> ().enabled = false;     	// Stop when fully open
		//door2.GetComponent<Animator> ().enabled = false;
		// Debug.Log("<color=red>Animator Disabled</color>");

		yield return new WaitForSeconds(6);                     // Wait 5 seconds

		// Close
		//door1.GetComponent<Animator> ().enabled = true;      	// Then close the doors
		//door2.GetComponent<Animator> ().enabled = true;
		anim.Play("Door1Close");	
		anim.Play("Door2Close");	
		doorSound.Play();
		//Debug.Log("<color=green>Animator Enabled</color>");

		yield return new WaitForSeconds(1);                     // Play the full closing half of animation

		// Stop
		//door1.GetComponent<Animator> ().enabled = false;     	// Then stop the door animations
		//door2.GetComponent<Animator> ().enabled = false;
		Debug.Log("<color=red>Door Animator Disabled</color>");

		buttonOn.SetActive(false);                          	// Hide the green button
		buttonOff.SetActive(true);                          	// Show the red button
	}
}
