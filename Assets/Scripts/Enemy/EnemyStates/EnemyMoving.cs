using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : BaseState
{   
    private Enemy_FSM _EFSM;

    public EnemyMoving(Enemy_FSM stateMachine) : base("moving", stateMachine)
    {
        _EFSM = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _EFSM.enemyAnim.Play("moving");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
