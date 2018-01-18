using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMoan : MonoBehaviour {

	public AudioSource audio;
	public AudioClip moan1;
	public AudioClip moan2;
	public AudioClip moan3;
	private int index;
	private int moanWait;
	private bool finished;

	void Start(){
		finished = true;
	}

	// Use this for initialization
	void Update () {
		if (finished == true)
			StartCoroutine (RandomFXGap ());
	}
		 
	IEnumerator RandomFXGap(){
		finished = false;

		moanWait = Random.Range (1, 4);
		yield return new WaitForSeconds(moanWait);	// 	Wait 1 to 3 seconds before playing the next moan clip

		index = Random.Range (1, 4);				// A number 1 to 3

		if (index == 1)
			audio.clip = moan1;
		if (index == 2)
			audio.clip = moan2;
		if (index == 3)
			audio.clip = moan3;
		
		audio.Play ();
		yield return new WaitForSeconds (audio.clip.length);
		finished = true;
	}
}
