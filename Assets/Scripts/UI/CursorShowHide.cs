// Joe O'Regan
// Menu Scenes
// Show or hide the cursor
// When the game loops back around after finishing, the cursor disappears in the score scene

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorShowHide : MonoBehaviour {

	//bool hideCursor;

	// Use this for initialization
	void Start () {
		// If in the name, score, or menu state, show cursor
		if (SceneManager.GetActiveScene ().buildIndex == 1 || SceneManager.GetActiveScene ().buildIndex == 2 || SceneManager.GetActiveScene ().buildIndex == 6)
			Cursor.visible = true;
		else
			Cursor.visible = false;


		//Cursor.visible = true;
		//Screen.showCursor = true;		// Obsolete api

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		//hideCursor = false;
	}
	/*
	void Update() {
		if ((SceneManager.GetActiveScene ().buildIndex == 1 || SceneManager.GetActiveScene ().buildIndex == 2 || SceneManager.GetActiveScene ().buildIndex == 6) && !hideCursor)
			Cursor.visible = true;		
		
		if (hideCursor) 
			Cursor.visible = false;	
	}
	*/

	public void HideCursor(){
		//hideCursor = true;
		Cursor.visible = false;	
		Cursor.lockState = CursorLockMode.Locked;
	}
}
