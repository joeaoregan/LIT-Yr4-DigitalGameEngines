/*
 * Created by:  Joe O'Regan
 *              K00203642
 * 
 * HighScores.cs
 * 
 * Using PlayerPrefs to save scores, after text files didn't work outside of editor
 * Works in WebGL, but scores are stored locally in the browser
 * Tested and works on Android
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

    public Text highScoresText;                                                                 // Display the high scores from file(s)
    public int numScores = 10;                                                                  // The number of scores to display
    
    //private bool clearTheScores = false;                                                      // Set to true to clear the scores in the editor

    void Start ()
    {
        // Get the players name and score from game controller and display high scores table
		string name = PlayerPrefs.GetString("PlayerName");
		int score = PlayerPrefs.GetInt ("Score");

		Debug.Log ("High Scores\nName: " + name + " Score: " + score);

		CheckHighScores(name, score);                  											// Check the high score
	}    

    public void CheckHighScores(string name, int score)
    {
        int tempScore = 0;
        string tempName = "";

        int[] arrScores = new int[numScores + 1];                                               // Array of high scores
        string[] arrNames = new string[numScores + 1];                                          // Array of names for high scores

        Debug.Log("Scores:\n");
        for (int i = 1; i <= numScores; i++)
        {
            arrScores[i-1] = PlayerPrefs.GetInt("Score" + i);
            arrNames[i-1] = PlayerPrefs.GetString("Name" + i);
            Debug.Log(arrNames[i - 1] + " " + arrScores[i - 1]);
        }

        // Set the end variables in each array to the current name and score
        arrScores[numScores] = score;
        arrNames[numScores] = name;

        // Set scores table heading
        if (score > arrScores[0])                                                               // If the current score is greater than the high score
            highScoresText.text = "New High Score:\n";                                          // Reset the scores table beginning with new high score message
        else if (arrScores[0] == 0)
            highScoresText.text = "No High Score Yet";                                          // Check that there actuall is a score yet
        else
            highScoresText.text = "High Scores:\n";                                             // Otherwise Reset the scores table with normal heading
        
        // Swap the scores
        for (int x = 1; x < (numScores + 1); x++)                                               // Check all the scores
        {
            for (int y = 0; y < (numScores+1) - x; y++)                                         // Against every other score
            {
                if (arrScores[y] < arrScores[y + 1])                                            // Sorting the largest score first
                {
                    tempScore = arrScores[y];                                                   // Do swapping
                    tempName = arrNames[y];

                    arrScores[y] = arrScores[y + 1];
                    arrNames[y] = arrNames[y + 1];

                    arrScores[y + 1] = tempScore;
                    arrNames[y + 1] = tempName;
                }
            }
        }

        // Display updated scores
        for (int i = 0; i < numScores; i++)
        {
            if (arrScores[i] == 0) continue;                                                     // No need to display if score is 0
            highScoresText.text += (i + 1) + ". " + arrNames[i] + " " + arrScores[i] + "\n";     // Showing name and score
        }

        // Set the new values in PlayerPrefs
        for (int i = 1; i <= numScores; i++)
        {
            PlayerPrefs.SetInt("Score" + i, arrScores[i-1]);                                     // Write the ordered score back to PlayerPrefs
            PlayerPrefs.SetString("Name" + i, arrNames[i-1]);                                    // and the player name
        }        
    }
}
