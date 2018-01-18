using UnityEngine;
using System.Collections;

public class ZombieMovement : MonoBehaviour
{
    Transform player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
	//int playerHealth = 10;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform; // can find the player with the Player tag
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }

	/*
		Move the Zombie towards the player
	*/
    void Update ()
	{
		//if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		//if(playerHealth > 0)
        //{
            nav.SetDestination (player.position);
        //}
       // else
        //{
      //      nav.enabled = false;
      //  }
    }
}
