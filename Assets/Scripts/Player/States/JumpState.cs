using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{
    private Player_FSM _psm;

    private Vector2 jumpDirection;
    private float jumpForce = 10f;
    
    public JumpState(Player_FSM stateMachine) : base("jump", stateMachine)
    {
        _psm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _psm.anim.Play("Jump");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        GroundCheck();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        
        _psm.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        if(GroundCheck())
        {
            _psm.ChangeState(_psm.idle);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

        private bool GroundCheck()
    {
        return _psm.player.GetComponent<groundCheck>().isGrounded;
    }
}
