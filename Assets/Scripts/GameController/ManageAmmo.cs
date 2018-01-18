// Joe O'Regan
// All Levels (Attached to player, could move to game controller)
// Manage the amount of ammo the player has to use

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;	// Get the build index

public class ManageAmmo : MonoBehaviour {

    public int CurrentAmmo;
    int InternalAmmo;
    int LoadedAmmo = 10;
    public Text AmmoText;

	private int totalAmmo;

	private int level;
	private Animation anim;

	private void Start() {
		totalAmmo = 0;
		//anim = AmmoText.GetComponent<Animation>();			// Get The AmmoText animation
		anim = AmmoText.gameObject.GetComponent<Animation>();
        InternalAmmo = LoadedAmmo;

		//level = SceneManager.GetActiveScene ().buildIndex - 2;	// Current level ...allowing for intro and menu scenes
		//if (level > 2)
		if (SceneManager.GetActiveScene ().buildIndex > 3) {
			CurrentAmmo = PlayerPrefs.GetInt ("Ammo");			// Get the ammo from the previous level
			Debug.Log ("Loaded Ammo: " + CurrentAmmo);
		}
    }

    // Update is called once per frame
    void Update () {
		InternalAmmo = CurrentAmmo;
		//if (GetComponent<ObjectiveComplete>().HasGun())
		if (!(SceneManager.GetActiveScene ().buildIndex == 3 && !GetComponent<ManageObjectives>().GetObjective1Complete()))
			AmmoText.text = "Ammo: " + InternalAmmo;
	}

	public int GetAmmo() { return CurrentAmmo; }				// used to save the ammo between levels
	public int GetTotalAmmo (){ return totalAmmo; }				// Get The total amound of ammo
	public void FireShot() { CurrentAmmo--; }					// Fire a shot, deduct 1 from ammo

	public void AddAmmo(int amount){
		CurrentAmmo += amount;
		anim.Play("HUDCanvasPanelTargetsText");					// Animate the text
		totalAmmo += amount;
	}


}
