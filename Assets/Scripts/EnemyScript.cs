using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public int enemyHealth = 10;
    
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    void DeductPoints(int DamageAmount)
    {
        enemyHealth -= DamageAmount;
    }
}

