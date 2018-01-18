// Joe O'Regan
// Level 1
// Target Range
// When the users accuracy percentage drops below 50
// This offers them an easy way out

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasyButtonPress : MonoBehaviour {

	public float distanceTo;													// Raycast distance to object
	public GameObject buttonOn;
	public GameObject buttonOff;
	public GameObject[] targets;

	private GameObject mainCam;													// Get the first person controller camera
	private Text infoMsg;														// Replaces actionText as information/action text in gam
	bool kidMode;

	private void Start()
	{		
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		infoMsg = GameObject.FindWithTag ("InfoMessage").GetComponent<Text> ();	// Get the action/information text object
		kidMode = false;
	}


	void Update ()
	{
		distanceTo = mainCam.GetComponent<PlayerCasting2> ().getDistanceFromTarget ();

		//if (distanceTo < 2.0f) {
		if (distanceTo < 2.0f && buttonOn.activeInHierarchy && !kidMode) {
			if (Input.GetButtonDown ("Action")) {                            // If the action button is pressed				
				// Activate the switch
				buttonOn.gameObject.SetActive (true);
				buttonOff.gameObject.SetActive (false);

				//MovingTarget.gameObject.SetActive (false);
				//MovingTarget.transform.localScale = new Vector3 (1.4f, 1.4f, 1.0f);

				//MovingTarget.transform.localScale += new Vector3 (0.2f, 0.2f, 0f);
				for(int i = 0; i < targets.Length; i++) {
					if (targets [i].activeInHierarchy) {
						targets [i].transform.localScale += new Vector3 (0.5f, 0f, 0.5f);
						if (i == 0)
							targets [i].transform.position += new Vector3 (4f, -1f, 0f);
					}
				}

				kidMode = true;
			}
		}
	}

    private void OnMouseOver()
    {
		if (distanceTo < 2.0f) {		
			if (buttonOn.activeInHierarchy) {
				infoMsg.text = "Press Action Button, Quitter!!!";
				StartCoroutine (ClearText ());
			} else {
					infoMsg.text = "Target Practice Easy Mode Switch";
			}

			StartCoroutine (ClearText ());
		}
	}

	IEnumerator ClearText(){
		yield return new WaitForSeconds (2);
		infoMsg.text = "";
	}

	void ButtonToggle(){
		buttonOn.gameObject.SetActive (!buttonOn.activeInHierarchy);
		buttonOff.gameObject.SetActive (!buttonOff.activeInHierarchy);
	}
}