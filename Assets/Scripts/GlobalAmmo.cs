using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour {

    public int CurrentAmmo;
    int InternalAmmo;
    int LoadedAmmo;
    public Text AmmoDisplay;

    private void Start()
    {
        InternalAmmo = LoadedAmmo;
    }

    // Update is called once per frame
    void Update () {
        InternalAmmo = CurrentAmmo;
        AmmoDisplay.text = "Ammo: " + InternalAmmo;
	}
}
