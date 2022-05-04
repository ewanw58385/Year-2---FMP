using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : BaseState
{
    private Enemy_FSM _EFSM;

     public EnemyIdle(Enemy_FSM stateMachine) : base("idle", stateMachine)
    {
        _EFSM = stateMachine;
    }

     public override void Enter()
    {
        base.Enter();

        _EFSM.enemyAnim.Play("Idle");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (Input.GetKeyDown(KeyCode.F))
        {
            _EFSM.ChangeState(_EFSM.moving);
        }
    }

    public override void UpdatePhysics()
    {

    }

    public override void Exit()
    {
        base.Exit();
    }
}
