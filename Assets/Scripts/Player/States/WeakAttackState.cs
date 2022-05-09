using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakAttackState : BaseState
{
    private Player_FSM _psm;
    private PlayerCombatManager _pcm;

    public WeakAttackState(Player_FSM stateMachine) : base("weakattack", stateMachine)
    {
        _psm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
    
        _pcm = _psm.GetComponent<PlayerCombatManager>();

        _psm.anim.Play("weak attack");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (_psm.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f) //if attack animation is at the point of hitting the enemy
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(_pcm.weakAttackPos.position, _pcm.weakAttackRange, _pcm.enemyLayer); //creates array of colliders which are within the boundary and are of the correct layermask 

            for(int i = 0; i < enemiesToDamage.Length; i++) //for each enemy in the array
            {
                enemiesToDamage[i].GetComponent<EnemyCombatManager>().ApplyDamage(_pcm.weakAttackDamage); //apply damage
            }
        }


        if (_psm.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
        {
            _psm.ChangeState(_psm.idle);
        }
    }

    public override void UpdatePhysics()
    {

    }
}
