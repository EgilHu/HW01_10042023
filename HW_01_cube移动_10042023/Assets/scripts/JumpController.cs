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
            // ʩ�����ϵ���ʹ��������Ծ
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false; // ��ֹ�����Ծ
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true; // ���������������ײʱ�����ٴ���Ծ
        }
    }
}
