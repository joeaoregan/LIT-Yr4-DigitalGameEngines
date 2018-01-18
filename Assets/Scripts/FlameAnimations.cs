/*
 	Creates random light flicker effect on the torch object 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimations : MonoBehaviour {

	public int LightMode;
	public GameObject FlameLight;


	void Update () {
		if (LightMode == 0)
			StartCoroutine (AnimateLight());
	}

	IEnumerator AnimateLight(){
		LightMode = Random.Range (1, 4);	// Never generates the maximum number
		if (LightMode == 1) {
			FlameLight.GetComponent<Animation> ().Play ("TorchAnim");
		}
		if (LightMode == 2) {
			FlameLight.GetComponent<Animation> ().Play ("TorchAnim2");
		}
		if (LightMode == 3) {
			FlameLight.GetComponent<Animation> ().Play ("TorchAnim3");
		}
		yield return new WaitForSeconds (0.99f);
		LightMode = 0;	// So Coroutine can be called again from update()
	}
}
