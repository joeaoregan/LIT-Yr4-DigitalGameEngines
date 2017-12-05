using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;	// Get the build index

public class GlobalAmmo : MonoBehaviour {

    public int CurrentAmmo;
    int InternalAmmo;
    int LoadedAmmo = 0;
    public Text AmmoDisplay;

	private int level;

    private void Start() {
        InternalAmmo = LoadedAmmo;

		level = SceneManager.GetActiveScene ().buildIndex;
		if (level > 1)
			CurrentAmmo = PlayerPrefs.GetInt("Ammo");		// Get the ammo from the previous level
    }

    // Update is called once per frame
    void Update () {
        InternalAmmo = CurrentAmmo;
        AmmoDisplay.text = "Ammo: " + InternalAmmo;
	}

	public int getAmmo(){  return CurrentAmmo; }			// used to save the ammo between levels
}
