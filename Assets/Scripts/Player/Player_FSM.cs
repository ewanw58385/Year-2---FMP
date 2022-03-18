using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_FSM : G_FSM //this is the StateMachine class for MOVEMENT. It inherits from the StateMachine class (so contains all functionality of the generic state machine)
{
    [HideInInspector]
    public IdleState idle; //holds references for the states for this machine 
    [HideInInspector]
    public WalkingState walking;
    [HideInInspector]
    public SpawnState spawn;
    [HideInInspector]
    public JumpState jump;

    [HideInInspector]
    public Transform player;
    public Rigidbody2D rb;
    public Animator anim;

    public float moveSpeed = 3.5f;

    public void Awake()
    {
        player = transform; //set the transform for states here 


        idle = new IdleState(this); //IdleState instance = new instance, passing "this" stateMachine as a parameter to the state's constructor 
                                    //(using overloading since the Base contstructor takes two parameters but only one is of type "StateMachine")

        walking = new WalkingState(this);
        spawn = new SpawnState(this);
        jump = new JumpState(this);

    }

    protected override BaseState GetInitialState() //overrides BaseState GetInitialState function to return the correct state
    {
        return spawn; //first state to be used. Can be whatever state you want. 
    }
}
