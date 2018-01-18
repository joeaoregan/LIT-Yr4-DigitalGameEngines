using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLabDoorSound : MonoBehaviour {

	AudioSource doorAudio;

	void Start(){
		doorAudio = GetComponent<AudioSource> ();
	}
			
	public void PlayLabDoorSound() {					// Call when objective completes
		StartCoroutine (PlayDoorSound ());			
	}

	IEnumerator PlayDoorSound(){
		yield return new WaitForSeconds (0.3f);
		doorAudio.Play ();
	}
}
