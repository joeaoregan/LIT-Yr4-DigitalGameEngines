// Joe O'Regan
// Object spawner
// Level 2 and 3

// Spawn an object/or randomly from a list of objects
// At one or more specified locations, again choosing randomly
// Initially spawning one randomly chosen object at each location
// Then choosing one location from the list randomly to spawn at
// a specified time interval

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

	public float timeToStartSpawns = 5.0f;
	public float timeBetweenSpawns = 6.0f;

	public GameObject[] spawnObject;			// List of objects to spawn (Zombies)
	//public Transform[] spawnPoints;			// List of spawn point coords
	public GameObject[] spawnPoints;			// List of spawn point coords

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");

		foreach (GameObject zombie in spawnPoints)
			Instantiate (spawnObject[Random.Range(0, spawnObject.Length)], zombie.transform.position, zombie.transform.rotation);					// Start the level spawning a random zombie from the list, at each spawn point

		InvokeRepeating ("SpawnZombie", timeToStartSpawns,timeBetweenSpawns);																		// Then start spawning objects, at a certain time, every specified amount of time
	}

	void SpawnZombie(){
		if (player.GetComponent<Ready>().ReadyToStart()){					// if the player is ready
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);																					// Select a random spawn point
			int index = Random.Range (0, spawnObject.Length);																							// Select a random object

			if (spawnPoints[spawnPointIndex].activeInHierarchy) {																						// If the game object is active in the hierarchy
				//Instantiate (spawnObject[index], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);						// Transform
				Instantiate (spawnObject[index], spawnPoints [spawnPointIndex].transform.position, spawnPoints [spawnPointIndex].transform.rotation);	// GameObject transform
			}
		}
	}
}
