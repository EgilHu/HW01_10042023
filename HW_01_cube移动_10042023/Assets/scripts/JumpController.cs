using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 5.0f;
    private bool canJump = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            // 施加向上的力使立方体跳跃
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false; // 防止多次跳跃
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true; // 当立方体与地面碰撞时可以再次跳跃
        }
    }
}
