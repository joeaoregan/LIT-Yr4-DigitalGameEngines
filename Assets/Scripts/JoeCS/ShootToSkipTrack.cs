using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootToSkipTrack: MonoBehaviour {

	public HiFiChangeTune master;				// Reference to main speaker with list of speakers, and songs

    public ManageScore score;					// Add to score when speaker is shot

	// Message is sent wehn raycast shot fired
    void DeductPoints(int DamageAmount)
    {
		score.currentScore += DamageAmount;		// Increment the score by 5
		master.nextTrack();						// Use the main speaker track list, to skip the track for all speakers
    }
}

