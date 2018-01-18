/*
 * Modified by: Joe O'Regan
 *              K00203642
 * 
 * TextInput.cs
 * Text Adventure Unity Tutorial
 * 
 * Allow the player to enter their name, 
 * and stored if score is in high scores
*/

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputText : MonoBehaviour {
	
    public InputField inputField;                               // Reference to the field for entering the Player name

	private string nameEntered;
	public Text displayName;

	List<string> actionLog  = new List<string>();

    private void Awake()
    {
        inputField.onEndEdit.AddListener(AcceptStringInput);    // When finished entering text call this function
        inputField.ActivateInputField();                       	// Ready to accept keyboard input
	}

	void Update(){
		//if (Input.GetKeyDown("Submit")) {
		if (Input.GetButtonDown("Submit")) {
			PlayerPrefs.SetString ("PlayerName", nameEntered);
			SceneManager.LoadScene (2);							// Load Menu
		}
	}

    void AcceptStringInput(string userInput)
    {
        LogStringWithReturn(userInput);                  		// If this is not here name is not entered correctly
        InputComplete();                                        // Finished entering text
    }

    void InputComplete()
    {
        DisplayLoggedText();                             		// Display the name entered
        inputField.ActivateInputField();                        // the input field is active
        inputField.text = null;                                 // Reset the inputField text
        inputField.enabled = false;                             // Unable to select the input field to enter text
    }


	// From text adventure tutorial
	public void LogStringWithReturn(string stringToAdd)
	{
		actionLog.Add(stringToAdd + "\n");
	}

	public void DisplayLoggedText()
	{
		nameEntered = string.Join("\n", actionLog.ToArray());
		displayName.text = nameEntered;                   		// Set the name at the top of the screen to the name entered
	}

 }
