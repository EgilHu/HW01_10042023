using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public enum CharacterState
    {
        Idle,
        Walk,
        Jump
    }

    public Text stateText; // 将Text组件拖拽到这里

    private CharacterState currentState = CharacterState.Idle;
    private bool isJumping = false;

    public static CharacterManager instance;

    // 单例模式的实例获取方法
    public static CharacterManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CharacterManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("CharacterManager");
                    instance = obj.AddComponent<CharacterManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // 确保只有一个实例存在
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // 处理输入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool jumpInput = Input.GetKeyDown(KeyCode.Space);

        // 更新状态机
        if (!isJumping)
        {
            if (Mathf.Abs(horizontalInput) > 0.1f|| Mathf.Abs(verticalInput)>0.1f)
            {
                ChangeState(CharacterState.Walk);
            }
            else
            {
                ChangeState(CharacterState.Idle);
            }

            if (jumpInput)
            {
                ChangeState(CharacterState.Jump);
            }
        }

        // 更新UI上的状态信息
        UpdateUI();
    }

    private void ChangeState(CharacterState newState)
    {
        if (newState != currentState)
        {
            currentState = newState;
            Debug.Log("Switching to state: " + currentState);

            // 在这里添加处理不同状态的逻辑
            switch (currentState)
            {
                case CharacterState.Idle:
                    // 处理Idle状态逻辑
                    break;

                case CharacterState.Walk:
                    // 处理Walk状态逻辑
                    break;

                case CharacterState.Jump:
                    // 处理Jump状态逻辑
                    isJumping = true;
                    Invoke("ResetJumpFlag", 1.0f); // 1.0秒后重置isJumping标志
                    break;
            }
        }
    }

    private void UpdateUI()
    {
        if (stateText != null)
        {
            stateText.text = "State: " + currentState.ToString();
        }
    }

    // 重置Jump状态标志
    private void ResetJumpFlag()
    {
        isJumping = false;
    }
}
