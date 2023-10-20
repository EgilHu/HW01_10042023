using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 90.0f;
    public Transform cameraTransform;

    private Vector3 moveDirection;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 计算移动方向
        Vector3 forward = cameraTransform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0;
        right.Normalize();

        moveDirection = (forward * verticalInput + right * horizontalInput).normalized;

        // 如果有移动输入
        if (moveDirection != Vector3.zero)
        {
            // 旋转Cube以适应移动方向
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // 移动Cube
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }

        // 让相机自动跟随Cube的旋转
        cameraTransform.rotation = Quaternion.LookRotation(-moveDirection, Vector3.up);

        // 更新相机位置
        cameraTransform.position = transform.position + Vector3.up * 2.0f - moveDirection * 5.0f;
    }
}