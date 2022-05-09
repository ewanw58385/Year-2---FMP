using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakAttackState : BaseState
{
    private Player_FSM _psm;

    private float horizontalInput;


    public WeakAttackState(Player_FSM stateMachine) : base("weakattack", stateMachine)
    {
        _psm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        _psm.anim.Play("weak attack");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (_psm.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
        {
            _psm.ChangeState(_psm.idle);
        }

    }

    public override void UpdatePhysics()
    {

    }
}
