using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public ManageScore score;
    public int scoreValue = 25;

    void DeductPoints(int DamageAmount)
    {
        score.currentScore += scoreValue;
    }
}
