// Joe O'Regan
// All Levels (Attached to player, could move to game controller)
// Manage the amount of ammo the player has to use

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;	// Get the build index

public class GlobalAmmo : MonoBehaviour {

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

		level = SceneManager.GetActiveScene ().buildIndex;
		if (level > 1)
			CurrentAmmo = PlayerPrefs.GetInt("Ammo");			// Get the ammo from the previous level
    }

    // Update is called once per frame
    void Update () {
        InternalAmmo = CurrentAmmo;
		AmmoText.text = "Ammo: " + InternalAmmo;
	}

	public int getAmmo(){  return CurrentAmmo; }				// used to save the ammo between levels

	public void AddAmmo(int amount){
		CurrentAmmo += amount;
		anim.Play("HUDCanvasPanelTargetsText");					// Animate the text
		totalAmmo += amount;
	}

	public int GetTotalAmmo (){
		return totalAmmo;
	}
}
