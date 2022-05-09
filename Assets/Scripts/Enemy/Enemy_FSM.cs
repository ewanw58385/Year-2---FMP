using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FSM : G_FSM
{
    [HideInInspector]public EnemyIdle idle;
    [HideInInspector]public EnemyMoving moving;
    [HideInInspector]public EnemyWeakAttackState weakattack;
    [HideInInspector]public EnemyHeavyAttackState heavyattack;

    [HideInInspector] public Animator enemyAnim;
    [HideInInspector] public EnemyAI enemyAI;
    [HideInInspector] public Rigidbody2D rb;

    public void Awake()
    {
        idle = new EnemyIdle(this);
        moving = new EnemyMoving(this);
        weakattack = new EnemyWeakAttackState(this);
        heavyattack = new EnemyHeavyAttackState(this);

        enemyAI = GetComponent<EnemyAI>(); //gets reference of the AI script for states to use 
        enemyAnim = transform.GetChild(0).GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected override BaseState GetInitialState() 
    {
        return idle;
    }
}
