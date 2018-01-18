using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2ZombieSpawner : MonoBehaviour {

	public GameObject zombieGuard;				// Zombie guard character
	public float gapBetweenSpawns = 5f;			// Every 5 seconds spawn a zombie guard
	public Transform[] spawnPoints;				// List of spawn point coords

	// Use this for initialization
	void Start () {
		//InvokeRepeating ("SpawnZombie", gapBetweenSpawns, gapBetweenSpawns);
		InvokeRepeating ("SpawnZombie", 3.0f, 7.0f);	// In 3 seconds call the function every 7 seconds
	}

	void SpawnZombie(){
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);	// select a random spawn point

		Debug.Log("Zombie Spawned");
		Instantiate (zombieGuard, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
	}
}
