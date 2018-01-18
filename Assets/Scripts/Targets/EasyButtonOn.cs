// Script to open doors, replaces javascript version

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasyButtonOn : MonoBehaviour {

	//public float distanceTo;													// Raycast distance to object
	public GameObject buttonOn;
	public GameObject buttonOff;

	private TargetScoreboard targetScoreboard;
	private int percent;
	//private AudioSource doorSound;
	//private Animation anim;													// Door animation
	//private GameObject mainCam;													// Get the first person controller camera
	//private Text infoMsg;														// Replaces actionText as information/action text in gam

	private void Start()
	{
		targetScoreboard = GetComponent<TargetScoreboard>();
		//mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		//infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();	// Get the action/information text object
		//anim = GetComponent<Animation>();										// Initialise the animation
		//doorSound = GetComponent<AudioSource>();
		//TheDistance = playerCasting.getDistanceFromTarget();    				// Initialise The Distance to Target
		//GameObject player = GameObject.FindGameObjectWithTag("Player");
		//playerCasting = player.GetComponent<PlayerCasting>();
	}


	void Update ()
	{
		//distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();

		percent = targetScoreboard.GetPercent ();

		if ((percent > 0 && percent < 50)) {
			// Activate the switch
			buttonOn.gameObject.SetActive (true);
			buttonOff.gameObject.SetActive (false);
		}
	}

	/*
    private void OnMouseOver()
    {
		if (distanceTo <= 2.0f)
        {
			infoMsg.text = "Press Action Button Quitter";
			StartCoroutine ("ClearText");
		}

		if (Input.GetButtonDown("Action")) {
			// Debug.Log("<color=red>Action Button Pressed</color>");
			if (distanceTo <= 2) {                   	 	// If the distance to the object is less than 2
				//StartCoroutine(OpenTheDoors());                              	// Call the open door function
				//StartCoroutine(OpenTheDoors2());                              	// Call the open door function
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
	*/
}
