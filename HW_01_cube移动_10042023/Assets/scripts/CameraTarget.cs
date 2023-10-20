using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Cube的Transform组件，用于跟随

    void Update()
    {
        if (target != null)
        {
            // 设置相机的位置为Cube的位置
            transform.position = target.position;

            // 设置相机的旋转与Cube的旋转一致
            transform.rotation = target.rotation;
        }
    }
}
