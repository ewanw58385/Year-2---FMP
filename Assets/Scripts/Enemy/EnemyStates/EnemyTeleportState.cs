using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeleportState : BaseState
{
    public Enemy_FSM _EFSM;

    public GameObject player;

    public EnemyTeleportState(Enemy_FSM statemachine) : base("teleport", statemachine)
    {
        _EFSM = statemachine;
    }

    public override void Enter()
    {
        base.Enter();

        player = GameObject.Find("Player");

        Vector2 teleportDirection = new Vector2(player.transform.position.x - _EFSM.transform.position.x, 0).normalized; //Vector2 variable to determine the direction the player is in

        //play teleport anim

        _EFSM.transform.position = new Vector2(player.transform.position.x - teleportDirection.x * 2, _EFSM.rb.position.y); //move the enemy's position to a new vector - Player's position on the x - the direction to teleport in multiplied by the distance teleported.

        //play teleport anim
        
        _EFSM.ChangeState(_EFSM.weakattack);
    }
}
