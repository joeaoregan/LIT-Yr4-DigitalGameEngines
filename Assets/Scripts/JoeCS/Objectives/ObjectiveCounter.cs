using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectiveCounter : MonoBehaviour {

	public Text objectiveText;
	public int completedObjectives;

	// Use this for initialization
	void Start () {
		completedObjectives = 0;

		UpdateObjectiveText ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateObjectiveText ();
		//objectiveText.GetComponent<Text> ().text = "Objectives: " + completedObjectives + "/4";
	}

	void UpdateObjectiveText() {
		if (SceneManager.GetActiveScene().buildIndex == 3)
			objectiveText.GetComponent<Text> ().text = "Objectives: " + completedObjectives + "/5";
		if (SceneManager.GetActiveScene().buildIndex == 4)
			objectiveText.GetComponent<Text> ().text = "Objectives: " + completedObjectives + "/2";
		if (SceneManager.GetActiveScene().buildIndex == 5)
			objectiveText.GetComponent<Text> ().text = "Objectives: " + completedObjectives + "/4";
	}

	public void incrementObjectives(){
		completedObjectives++;
	}

	public int getObjectiveCount() {
		return completedObjectives;
	}
}
