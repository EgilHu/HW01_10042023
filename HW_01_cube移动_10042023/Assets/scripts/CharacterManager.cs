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

    public Text stateText; // ��Text�����ק������

    private CharacterState currentState = CharacterState.Idle;
    private bool isJumping = false;

    public static CharacterManager instance;

    // ����ģʽ��ʵ����ȡ����
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
        // ȷ��ֻ��һ��ʵ������
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
        // ��������
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool jumpInput = Input.GetKeyDown(KeyCode.Space);

        // ����״̬��
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

        // ����UI�ϵ�״̬��Ϣ
        UpdateUI();
    }

    private void ChangeState(CharacterState newState)
    {
        if (newState != currentState)
        {
            currentState = newState;
            Debug.Log("Switching to state: " + currentState);

            // ��������Ӵ���ͬ״̬���߼�
            switch (currentState)
            {
                case CharacterState.Idle:
                    // ����Idle״̬�߼�
                    break;

                case CharacterState.Walk:
                    // ����Walk״̬�߼�
                    break;

                case CharacterState.Jump:
                    // ����Jump״̬�߼�
                    isJumping = true;
                    Invoke("ResetJumpFlag", 1.0f); // 1.0�������isJumping��־
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

    // ����Jump״̬��־
    private void ResetJumpFlag()
    {
        isJumping = false;
    }
}
