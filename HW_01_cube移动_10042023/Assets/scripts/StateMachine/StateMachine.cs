using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{
    public Text stateText;
    public BaseState currentState
    {
        get; // ��ȡ��ǰ״̬(BaseState currentState = playerStateMachine.currentPlayerState;)
        set;// �����µ�״̬(BaseStateMachine.currentPlayerState = newState;)
    }

    public void ChangeState(BaseState newState)
    {
        currentState.ExitState();

        currentState = newState;

        // �����ǰ״̬�����֣��� "null"�����״̬Ϊ�գ�
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

    // ��ȡ��ʼ״̬�����ⷽ���������������и���
    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    private void UpdateUI()
    {
        if (stateText != null)
        {
            // ��ȡ��ǰ״̬������
            string content = currentState != null ? currentState.name : "(no current state)";
            stateText.text = content;
        }
    }
}
