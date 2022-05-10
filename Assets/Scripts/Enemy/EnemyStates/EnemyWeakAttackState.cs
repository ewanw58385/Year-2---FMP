using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeakAttackState : BaseState
{
    private Enemy_FSM _EFSM;

    public EnemyWeakAttackState(Enemy_FSM stateMachine) : base("weakattack", stateMachine)
    {
        _EFSM = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        //_EFSM.rb.velocity = Vector2.zero; //disable velocity while player is attacking

        _EFSM.enemyAnim.Play("weakattack");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (_EFSM.enemyAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f) //if anim finished
        {
            _EFSM.ChangeState(_EFSM.heavyattack); //transition to moving state 
        }

        if (_EFSM.hitCondition == true)
        {
            _EFSM.ChangeState(_EFSM.hitstate);
        }

    }
}
