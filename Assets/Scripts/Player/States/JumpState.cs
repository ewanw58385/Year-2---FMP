using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class JumpState : BaseState 
{
    private Player_FSM _psm;

    private float horizontalInput;
    private Vector2 jumpDirection; 

    private bool _isGrounded;

    public JumpState(Player_FSM stateMachine) : base("jump", stateMachine)
    {
        _psm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        _psm.rb.AddForce(Vector2.up * _psm.jumpForce, ForceMode2D.Impulse);
        _psm.anim.SetBool("Jump", true);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

            horizontalInput = Input.GetAxisRaw("Horizontal"); //gets axis as vector2
            _psm.rb.velocity = new Vector2(horizontalInput * _psm.jumpMoveSpeed, _psm.rb.velocity.y); //applies velocity on the X axis while in the air without affecting Y velocity from jump

        if(_psm.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.3f && _psm.GroundCheck())
        {
            _psm.ChangeState(_psm.idle);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

