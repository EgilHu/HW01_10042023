using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateMachine : StateMachine
{
    public IdleState idleState;
    public WalkState walkState;

    //public new Rigidbody rigidbody;
    //public float moveSpeed = 5.0f;
    //public float rotationSpeed = 90.0f;

    private void Awake()
    {
        idleState = new IdleState(this);
        walkState = new WalkState(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

}