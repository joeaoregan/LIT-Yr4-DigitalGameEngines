/*
 	Use singleton pattern to keep same player between levels
	Main problem is it keeps its previous position, and falls
	out of the scene
	Also does not pick up objects after first level, as scripts are tied to components of 
	each scenes player instance

	But it does keep the same instance of player across scenes
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerSingleton : MonoBehaviour {

	private GameObject player;

	//private bool level2Position;
	//private bool level3Position;
	
	public static PlayerSingleton instance = null;			// Singleton used to keep instance of player

	public static PlayerSingleton Instance {
		get { return instance; }							// Returns an instance of player
	}

	// Use this for initialization
	void Awake () {		
		player = GameObject.FindWithTag ("Player");

		if (instance != null && instance != this) {			// If there is an existing music player
			
			//GetComponent<Transform> ().position = new Vector3 (0.3f, 8.85f, 23.2f);
			//GetComponent<Transform> ().position = new Vector3 (-21.5f, -13.9f, 27.6f);

			Destroy (this.gameObject);						// Destroy this one, don't need to

			//player.GetComponent<Transform>().position = new Vector3 (-21.5f, -13.9f, 27.6f);
			//player.GetComponent<Transform>().position = new Vector3 (-21.5f, -13.9f, 27.6f);
			SetPosition ();

			return;											// skip the rest
		} else {											// Otherwise
			instance = this;								// There is no music player, use this
			//player.GetComponent<Transform>().position = new Vector3 (-21.5f, -13.9f, 27.6f);

			SetPosition ();
		}

		DontDestroyOnLoad (this.gameObject);				// Don't destroy when the scene loads (object script is attached to)

		Debug.Log ("Test");

		//SetPosition ();
		//level2Position = false;
		//level3Position = false;
	}

	void Update() {
		//SetPosition ();
	}

	void SetPosition() {
		//if (SceneManager.GetActiveScene ().buildIndex == 4 && !level2Position) {
		if (SceneManager.GetActiveScene ().buildIndex == 4) {									// Starting position level 2 (otherwise player falls away into the unity abyss)
			//Debug.Log("Set Level 2 Position");
			//player.GetComponent<Transform> ().position = new Vector3 (0.3f, 8.85f, 23.2f);
			player.GetComponent<Transform> ().position = new Vector3 (0.3f, 8.85f, 23.2f);
			//GetComponent<Transform> ().Rotate(new Vector3 (0, 180, 0));
			player.GetComponent<Transform> ().rotation = Quaternion.Euler (0, 180, 0);
			//level2Position = true;
		}
		//if (SceneManager.GetActiveScene ().buildIndex == 5 && !level3Position) {	
		if (SceneManager.GetActiveScene ().buildIndex == 5) {									// Starting position level 3
			player.GetComponent<Transform> ().position = new Vector3 (-21.5f, -15.95f, 27.6f);
			player.GetComponent<Transform> ().rotation = Quaternion.Euler (0, 90, 0);
		}
	}

	/*
	void SetPosition() {
		if (SceneManager.GetActiveScene ().buildIndex == 4 && !level2Position) {				// Starting position level 2 (otherwise player falls away into the unity abyss)
			Debug.Log("Set Level 2 Position");
			GetComponent<Transform> ().position = new Vector3 (0.3f, 8.85f, 23.2f);
			//GetComponent<Transform> ().Rotate(new Vector3 (0, 180, 0));
			GetComponent<Transform> ().rotation = Quaternion.Euler (0, 180, 0);
			level2Position = true;
		}
		if (SceneManager.GetActiveScene ().buildIndex == 5 && !level3Position) {				// Starting position level 3
			SetL3Position();
		}
	}

	public void SetL3Position(){
		Debug.Log("Set Level 3 Position");
		GetComponent<Transform> ().position = new Vector3 (-21.5f, -13.9f, 27.6f);
		//GetComponent<Transform> ().Rotate(new Vector3 (0, 90, 0));
		GetComponent<Transform> ().rotation = Quaternion.Euler (0, 90, 0);
		level3Position = true;
	}
	*/
}
