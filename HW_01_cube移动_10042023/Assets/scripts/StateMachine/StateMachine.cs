using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{
    public Text stateText;
    public BaseState currentState
    {
        get; // 获取当前状态(BaseState currentState = playerStateMachine.currentPlayerState;)
        set;// 设置新的状态(BaseStateMachine.currentPlayerState = newState;)
    }

    public void ChangeState(BaseState newState)
    {
        currentState.ExitState();

        currentState = newState;

        // 输出当前状态的名字（或 "null"，如果状态为空）
        string content = currentState != null ? currentState.name : "null";
        Debug.Log(content);

        currentState.EnterState();

        UpdateUI();
    }

    void Start()
    {
        currentState = GetInitialState();
        UpdateUI();
    }

    void Update()
    {
        currentState.UpdateLogic();
    }

    // 获取初始状态的虚拟方法，可以在子类中覆盖
    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    private void UpdateUI()
    {
        if (stateText != null)
        {
            // 获取当前状态的名称
            string content = currentState != null ? currentState.name : "(no current state)";
            stateText.text = content;
        }
    }
}
