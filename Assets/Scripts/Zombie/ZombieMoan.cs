using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMoan : MonoBehaviour {

	AudioSource zombieAudio;

	public AudioClip moan1;
	public AudioClip moan2;
	public AudioClip moan3;

	private int index;
	private int moanWait;
	private bool finished;

	void Start(){
		finished = true;
		zombieAudio = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Update () {
		if (finished == true && GetComponent<ZombieHealth>().currentHealth > 0)
			StartCoroutine (RandomFXGap ());
	}
		 
	IEnumerator RandomFXGap(){
		finished = false;

		moanWait = Random.Range (1, 4);
		yield return new WaitForSeconds(moanWait);	// 	Wait 1 to 3 seconds before playing the next moan clip

		index = Random.Range (1, 4);				// A number 1 to 3

		if (index == 1)
			zombieAudio.clip = moan1;
		if (index == 2)
			zombieAudio.clip = moan2;
		if (index == 3)
			zombieAudio.clip = moan3;
		
		zombieAudio.Play ();
		yield return new WaitForSeconds (zombieAudio.clip.length);
		finished = true;
	}
}
