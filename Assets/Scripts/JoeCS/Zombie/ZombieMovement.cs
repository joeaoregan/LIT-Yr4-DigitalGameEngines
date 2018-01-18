using UnityEngine;
using System.Collections;

public class ZombieMovement : MonoBehaviour
{
    private Transform playerPos;
    PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
	//int playerHealth = 10;
    UnityEngine.AI.NavMeshAgent nav;

	//private bool attackPlayer;

	//public bool getAttack(){
	//	return attackPlayer;
	//}

	Animator anim;

    void Awake ()
    {		
        playerPos = GameObject.FindGameObjectWithTag ("Player").transform; // can find the player with the Player tag
        playerHealth = playerPos.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent<Animator> ();

		nav.speed = Random.Range (2, 6);								// Pick a random speed from 2 to 5

		//attackPlayer = true;
    }

	/*
		Move the Zombie towards the player
	*/
    void Update ()
	{
		if (!GetComponent<ZombieHealth> ().isWounded() && !GetComponent<ZombieAttack>().IsScreaming()) {
			if (GetComponent<ZombieHealth> ().currentHealth > 0 && playerHealth.currentHealth > 0) {
				nav.SetDestination (playerPos.position);
			} else {
				nav.enabled = false;
				if (GetComponent<ZombieHealth> ().currentHealth > 0) 	// If still alive 
				anim.SetTrigger ("Idle");								// Set to idle animation loop
			}
		}
    }
}
