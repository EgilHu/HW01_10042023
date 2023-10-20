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

        // �����ƶ�����
        Vector3 forward = cameraTransform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0;
        right.Normalize();

        moveDirection = (forward * verticalInput + right * horizontalInput).normalized;

        // ������ƶ�����
        if (moveDirection != Vector3.zero)
        {
            // ��תCube����Ӧ�ƶ�����
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // �ƶ�Cube
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }

        // ������Զ�����Cube����ת
        cameraTransform.rotation = Quaternion.LookRotation(-moveDirection, Vector3.up);

        // �������λ��
        cameraTransform.position = transform.position + Vector3.up * 2.0f - moveDirection * 5.0f;
    }
}