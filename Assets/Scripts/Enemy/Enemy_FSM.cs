using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FSM : G_FSM
{
    [HideInInspector]
    public EnemyIdle idle;
    public EnemyMoving moving;

    public bool chasingPlayer;

    [HideInInspector] public Transform enemyVFX;  
    [HideInInspector] public Animator enemyAnim;

    public void Awake()
    {
        idle = new EnemyIdle(this);
        moving = new EnemyMoving(this);

        enemyVFX = transform.GetChild(0);
        enemyAnim = enemyVFX.GetComponent<Animator>();
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("moving towards player");
            chasingPlayer = true;
        }
    }
    
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("stationary");
            chasingPlayer = false;
        }
    }

    protected override BaseState GetInitialState() 
    {
        return idle;
    }
}
