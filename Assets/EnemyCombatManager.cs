using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatManager : MonoBehaviour
{
    [HideInInspector]public Animator anim;

    public float enemyHealth = 9;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    
    public void ApplyDamage(float damageTaken)
    {                
        enemyHealth =  enemyHealth - damageTaken; //deduct damage to health
        
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
