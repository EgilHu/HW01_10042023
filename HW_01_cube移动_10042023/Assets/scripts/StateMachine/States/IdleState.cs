using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Playables;

public class IdleState : BaseState
{
    private float _horizontalInput;
    private float _verticalInput;

    public IdleState(MovementStateMachine stateMachine) : base("IdleState", stateMachine) { }

    public override void EnterState()
    {
        base.EnterState();
        _horizontalInput = 0f;
        _verticalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon || Mathf.Abs(_verticalInput) > Mathf.Epsilon)
            stateMachine.ChangeState(((MovementStateMachine)stateMachine).walkState);
    }
}
