using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Different type of behaviour to monobehaviour
public class LoadScoresOnDeath : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		SceneManager.LoadScene(6);		// Load the high scores table when the player dies
	}
}
