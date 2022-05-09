using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatManager : MonoBehaviour
{
    [HideInInspector]public Animator anim;

    public GameObject hitVFX;
    public Transform hitVFXPosition;

    public float enemyHealth = 9;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        hitVFXPosition = transform.Find("HitVFXPosition");
    }

    void Update()
    {
        Debug.Log(enemyHealth);

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public void ApplyDamage(float damageTaken)
    {        
        anim.Play("hitAnim");
        Instantiate(hitVFX, hitVFXPosition.position, Quaternion.identity);

        enemyHealth =  enemyHealth - damageTaken;
    }
}
