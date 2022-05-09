using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatManager : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    
    public void ApplyDamage(float damageTaken)
    {
        Debug.Log("Taken " + damageTaken + " damage!");
        
        anim.Play("hitVFX");
    }
}
