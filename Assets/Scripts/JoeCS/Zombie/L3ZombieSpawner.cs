using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3ZombieSpawner : MonoBehaviour {

	public GameObject zombieGuard;				// Zombie guard character
	public GameObject zombieGirl;				// Zombie girl character
	//public float gapBetweenSpawns = 5f;			// Every 5 seconds spawn a zombie guard
	public Transform[] spawnPoints;				// List of spawn point coords

	public GameObject SpawnPoint1;
	public GameObject SpawnPoint2;

	// Use this for initialization
	void Start () {
		//InvokeRepeating ("SpawnZombie", gapBetweenSpawns, gapBetweenSpawns);
		InvokeRepeating ("SpawnZombie", 5.0f, 7.0f);	// In 3 seconds call the function every 7 seconds
	}

	void SpawnZombie(){
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);				// select a random spawn point

		if ((spawnPointIndex == 0 && SpawnPoint1.activeInHierarchy) || (spawnPointIndex == 1 && SpawnPoint2.activeInHierarchy)) {
			Debug.Log ("Zombie Spawned at spawnpoint: " + spawnPointIndex);

			if (Random.Range (1, 3) == 1)
				Instantiate (zombieGuard, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			else
				Instantiate (zombieGirl, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		}
	}
}
