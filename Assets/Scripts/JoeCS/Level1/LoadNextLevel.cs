using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Different type of behaviour to monobehaviour
public class LoadNextLevel : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (SceneManager.GetActiveScene().buildIndex == 3)
			SceneManager.LoadScene(4);								// Load level 2
		else if (SceneManager.GetActiveScene().buildIndex == 4)
			SceneManager.LoadScene(5);								// Load level 3
	}
}
