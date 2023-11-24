using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Playables;

public class WalkState : BaseState
{
    private float _horizontalInput;
    private float _verticalInput;

    //private MovementStateMachine _sm;
    public WalkState(MovementStateMachine stateMachine) : base("WalkState", stateMachine) {
        //_sm =(MovementStateMachine)stateMachine;
    }

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
        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon || Mathf.Abs(_verticalInput) < Mathf.Epsilon)
            stateMachine.ChangeState(((MovementStateMachine)stateMachine).idleState);
    }

    //public override void UpdatePhysics()
    //{
    //    base.UpdatePhysics();

    //    // 计算移动方向
    //    Vector3 localVelocity = _sm.rigidbody.transform.InverseTransformDirection(_sm.rigidbody.velocity);
    //    localVelocity.x = _horizontalInput *_sm.moveSpeed;
    //    localVelocity.y = _sm.rigidbody.velocity.y; // 保留垂直速度
    //    localVelocity.z = _verticalInput * _sm.moveSpeed;
    //    _sm.rigidbody.velocity = localVelocity;

    //    Vector3 forward = _sm.transform.forward;
    //    forward.y = 0;
    //    forward.Normalize();

    //    Vector3 right = _sm.transform.right;
    //    right.y = 0;
    //    right.Normalize();
    //    Vector3 moveDirection = (forward * _verticalInput + right * _horizontalInput).normalized;

    //    // 旋转角色以面向移动方向
    //    if (moveDirection != Vector3.zero)
    //    {
    //        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
    //        _sm.transform.rotation = Quaternion.RotateTowards(_sm.transform.rotation, targetRotation, _sm.rotationSpeed * Time.deltaTime);
    //    }

    //}
}
