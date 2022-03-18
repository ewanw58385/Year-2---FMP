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
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        horizontalInput = Input.GetAxisRaw("Horizontal"); //gets axis as vector2

        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            _psm.ChangeState(_psm.jump);
        }
        
        if (horizontalInput != 0)
        {
            _psm.ChangeState(_psm.walking);
        }
    }

    private bool GroundCheck()
    {
        return _psm.player.GetComponent<groundCheck>().isGrounded;
    }
}
