using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;		// Text object

public class Objective : MonoBehaviour {

  //  public bool hasGun;
	public Text actionText;
    
	void Start () {
 //       hasGun = false;
		StartCoroutine ("FirstObjective");
	}

//    public bool PlayerHasGun() {
//        return hasGun;
//    }

 //   public void SetHasGun(bool setValue) { hasGun = setValue; }


	// Update is called once per frame
	IEnumerator FirstObjective () {
		actionText.GetComponent<Text> ().text = "Objective 1:\nFind A Gun";				// Display message
		yield return new WaitForSeconds (2);											// Wait for the amount of time
		actionText.GetComponent<Text> ().text = "";										// Then clear the message
	}
}
