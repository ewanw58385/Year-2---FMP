using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    private Player_FSM _psm;

    private float horizontalInput;


    public IdleState(Player_FSM stateMachine) : base("idle", stateMachine)
    {
        _psm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        _psm.anim.Play("Idle");
        _psm.anim.SetBool("Jump", false);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        horizontalInput = Input.GetAxisRaw("Horizontal"); //gets horizontal axis as float

        if (Input.GetKeyDown(KeyCode.Space) && _psm.GroundCheck())
        {
            _psm.ChangeState(_psm.jump);
        }
        
        if (horizontalInput != 0)
        {
            _psm.ChangeState(_psm.walking);
        }
    }
}