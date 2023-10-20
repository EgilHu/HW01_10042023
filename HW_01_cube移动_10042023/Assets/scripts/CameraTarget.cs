using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Cube��Transform��������ڸ���

    void Update()
    {
        if (target != null)
        {
            // ���������λ��ΪCube��λ��
            transform.position = target.position;

            // �����������ת��Cube����תһ��
            transform.rotation = target.rotation;
        }
    }
}
