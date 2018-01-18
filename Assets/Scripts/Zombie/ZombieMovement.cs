// Joe O'Regan
// Levels 2 & 3
// Move the zombie towards the players coordinates using a nav mesh agent

using UnityEngine;
using System.Collections;

public class ZombieMovement : MonoBehaviour
{
    private Transform playerPos;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
	//int playerHealth = 10;
    UnityEngine.AI.NavMeshAgent nav;

	private GameObject gc;

	//private bool attackPlayer;

	//public bool getAttack(){
	//	return attackPlayer;
	//}

	bool move;
	bool idleAnim;
	bool walkAnim;
	bool dyingAnim;

	Animator anim;
	GameObject player;

    void Awake ()
	{		
		gc = GameObject.FindWithTag ("GameController");
		gc.GetComponent<ManageZombies> ().PauseZombies (false);					// Zombies are moving
		player = GameObject.FindWithTag ("Player");
        playerPos = GameObject.FindGameObjectWithTag ("Player").transform; 		// can find the player with the Player tag
        //playerHealth = playerPos.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent<Animator> ();

		nav.speed = Random.Range (2, 6);										// Pick a random speed from 2 to 5


		move = true;
		idleAnim = false;
		walkAnim = false;
		dyingAnim = false;

		anim.SetTrigger ("Alive");
		IdleAnimation ();
    }

	void ZombiePaused(){
		move = gc.GetComponent<ManageZombies> ().ZombiesPaused ();		// Are the zombies paused from moving

		if (!move) {
			nav.enabled = false;
		} else {
			//anim.SetTrigger ("Walk");									// Set to idle animation loop
			nav.enabled = true;
			if (player.GetComponent<PlayerHealth>().currentHealth > 0)
				nav.SetDestination (playerPos.position);
		}

		if (!move) {
			idleAnim = false;
			IdleAnimation ();
		}
	}

	//	Move the Zombie towards the player	
    void Update ()
	{		
		if (player.GetComponent<Ready> ().ReadyToStart () && !move && GetComponent<ZombieHealth> ().currentHealth > 0 && player.GetComponent<PlayerHealth>().currentHealth > 0) {
			nav.SetDestination (playerPos.position);
			move = true;
		} else {
			move = false;
		}

		//ZombiePaused ();


		if (!GetComponent<ZombieHealth> ().isWounded() && !GetComponent<ZombieAttack>().IsScreaming() && move) {
			if (GetComponent<ZombieHealth> ().currentHealth > 0 && player.GetComponent<PlayerHealth>().currentHealth > 0) {
				nav.SetDestination (playerPos.position);
			} else {
				nav.enabled = false;
				//idleAnim = true;
				if (GetComponent<ZombieHealth> ().currentHealth > 0)
					anim.SetTrigger ("Idle2");
			}
		}

		//MoveAnimation ();
		//IdleAnimation ();
		//DeathAnimation ();
    }

	void MoveAnimation(){
		if (!walkAnim && move) {
			anim.SetTrigger ("Walk");
			walkAnim = true;
		}
	}

	// Pick a random Idle animation from the idle loop in the animator
	void IdleAnimation(){
		
		if (GetComponent<ZombieHealth> ().currentHealth > 0 && idleAnim == false) {	// If still alive 
				int choice = Random.Range (0, 3);
				if (choice == 0)
					anim.SetTrigger ("Idle1");										// Set to idle animation loop
				else if (choice == 1)
					anim.SetTrigger ("Idle2");
				else if (choice == 2)
					anim.SetTrigger ("Idle3");
		
				idleAnim = true;
		}

		if (GetComponent<ZombieHealth> ().currentHealth < 0) {
			anim.SetTrigger ("isDying");											// If the zombies has no health trigger death animation
		}
	}

	void DeathAnimation(){
		
		if (GetComponent<ZombieHealth> ().currentHealth < 0 & !dyingAnim) {
			anim.SetTrigger ("isDying");											// If the zombies has no health trigger death animation
			dyingAnim = true;
		}
	}
}
