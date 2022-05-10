using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitState : BaseState
{
    private Enemy_FSM _EFSM;
    private EnemyCombatManager _ECM;

    private GameObject player;
    public float knockbackForce = 40;

    public EnemyHitState(Enemy_FSM statemachine) : base("hitstate", statemachine)
    {
        _EFSM = statemachine;
    }

    public override void Enter()
    {
        base.Enter();

        _ECM = _EFSM.transform.GetComponent<EnemyCombatManager>(); //gets reference to combat manager for deducting health 

        player = GameObject.Find("Player"); //for applying a knockback effect in the right direction
        
        _EFSM.enemyAnim.Play("hitAnim"); //plays hit anim
        _ECM.ApplyDamage(_EFSM.damageTaken); //calls the apply damage function from the EnemyCombatManager, passing the damageTaken parameter (set in the player attack state) as the damage to be deducted
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        if (_EFSM.enemyAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.2f) //if attack animation has finished 
        {
            float randomNumber = Random.Range(0, 1);
        
            if (randomNumber == 0) //knockback
            {
                Vector2 knockbackDirection = new Vector2(player.transform.position.x - _EFSM.transform.position.x, 0).normalized;
                _EFSM.rb.AddForce(-knockbackDirection * knockbackForce);
                _EFSM.ChangeState(_EFSM.weakattack);
            }
            else //teleport
            {
                _EFSM.ChangeState(_EFSM.teleport);
            }
        }

    }

    public override void Exit()
    {
        base.Exit();

        _EFSM.damageTaken = 0f; //reset the damage float 
        _EFSM.hitCondition = false; //reset the condition to transition to this state
    }

}
