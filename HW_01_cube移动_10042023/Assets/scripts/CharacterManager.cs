using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    //public static CharacterManager Instance { get; private set; }
    public static CharacterManager instance;
    //private static CharacterManager instance;


    public float moveSpeed = 5.0f;
    public float rotationSpeed = 90.0f;
    public float jumpForce = 5.0f;
    public int maxJumps = 3;

    private Vector3 moveDirection;
    private int jumpsRemaining;
    private bool canJump = true;
    private Rigidbody rb;
    private GameObject Player;
    public bool ReachGround;

    private void Awake()
    {
        // 设置CharacterManager实例，确保只有一个实例
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void MoveCharacter()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 移动逻辑（与原始代码相同）
      
        // 计算移动方向
        Vector3 forward = Player.transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = Player.transform.right;
        right.y = 0;
        right.Normalize();

        moveDirection = (forward * verticalInput + right * horizontalInput).normalized;

        // 如果有移动输入
        if (moveDirection != Vector3.zero)
        {
            // 旋转Cube以适应移动方向
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            Player.transform.rotation = Quaternion.RotateTowards(Player.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // 移动Cube
            Player.transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
       
        }
    }

    public void JumpCharacter()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (jumpsRemaining > 0 || canJump))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset vertical velocity
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpsRemaining--;

        if (jumpsRemaining <= 0)
        {
            canJump = false;
        }
    }

    public void Update()
    {
        Player = GameObject.FindWithTag("Player");
        rb = Player.GetComponent<Rigidbody>();
        jumpsRemaining = maxJumps;
        if (ReachGround)
        {
            jumpsRemaining = maxJumps; // 每次落地都重置 jumpsRemaining
            canJump = true;
        }
    }
}
