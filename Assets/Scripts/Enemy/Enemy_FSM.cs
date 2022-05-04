using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FSM : G_FSM
{
    [HideInInspector]
    public EnemyIdle idle;
    public EnemyMoving moving;

    public Transform enemyVFX;  
    public Animator enemyAnim;

    public void Awake()
    {
        idle = new EnemyIdle(this);
        moving = new EnemyMoving(this);

        enemyVFX = transform.GetChild(0);
        enemyAnim = enemyVFX.GetComponent<Animator>();
    }

    protected override BaseState GetInitialState() 
    {
        return idle;
    }
}
