using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiFiChangeTune: MonoBehaviour {
	
	public Text actionText;						// Display track skipped message

	public AudioSource[] Speakers;				// list of speakers
	public AudioClip[] tracks;					// list of tracks

    public ManageScore score;

	private int i = 0;												// The index used to select the track from tracks array

	void Start(){
		ChangeClip ();												// Start by playing track 0, the first track in the list
	}

    void DeductPoints(int DamageAmount)
    {
		score.currentScore += DamageAmount;							// Increment the score by 5
		//i++;														// Move onto next track in array
		nextTrack();											// Increment, and loop back to start when end reached
		//SelectClip ();											// Select the clip to play
		//ChangeClip ();												// Select the first track, for all speakers
    }

	//void SelectClip(){
		//for(int i 
	//}

	// get next track in list, or back to start
	public void nextTrack(){
		if ( i < tracks.Length-1) i++;								// increment i
		else i = 0;													// go back to the beginning
		ChangeClip();												// Add here to call when other speakers are shot
	}

	/*
		Change the track on every speaker
	 */
	void ChangeClip() {
		StartCoroutine (TrackSkippedMessage ());
		foreach (AudioSource speaker in Speakers) {					// For each speaker in the list of speakers
			speaker.clip = tracks[i];								// Set the same clip for all the speakers
			speaker.Play ();										// And play the new track
		}
	}

	IEnumerator TrackSkippedMessage(){
		actionText.GetComponent<Text> ().text = "Track Skipped";	// Display track skipped message
		yield return new WaitForSeconds(2);							// Show action text for 2 seconds
		actionText.GetComponent<Text> ().text = "";					// clear action text

	}
}

