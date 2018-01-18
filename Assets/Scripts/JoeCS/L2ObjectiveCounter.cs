using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L2ObjectiveCounter : MonoBehaviour {

	public Text objectiveText;
	public int completedObjectives;

	// Use this for initialization
	void Start () {
		objectiveText.GetComponent<Text> ().text = "Objectives: " + completedObjectives + "/3";
	}
	
	// Update is called once per frame
	void Update () {
			objectiveText.GetComponent<Text> ().text = "Objectives: " + completedObjectives + "/3";
	}

	public void incrementObjectives(){
		completedObjectives++;
	}

	public int getObjectiveCount() {
		return completedObjectives;
	}
}
