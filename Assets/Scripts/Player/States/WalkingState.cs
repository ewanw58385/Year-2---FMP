
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : BaseState
{
    private Player_FSM _psm;



    private float horizontalInput;


    public WalkingState(Player_FSM stateMachine) : base("walking", stateMachine) {
        _psm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _psm.anim.Play("Walking");
        _psm.anim.SetBool("Jump", false);

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _psm.anim.SetFloat("HorizontalInput", horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && _psm.GroundCheck())
        {
            _psm.ChangeState(_psm.jump);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
                
        horizontalInput = Input.GetAxisRaw("Horizontal"); //gets axis as vector2
        _psm.rb.MovePosition(new Vector2 (_psm.player.position.x + horizontalInput * _psm.moveSpeed * Time.deltaTime, _psm.player.position.y + 0 * _psm.moveSpeed * Time.deltaTime));


        if (horizontalInput == 0)
        {
            _psm.ChangeState(_psm.idle);
        }
    }
}