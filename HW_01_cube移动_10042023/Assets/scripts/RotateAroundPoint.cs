using UnityEngine;

public class GyroscopeRotation : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // 旋转速度

    void Update()
    {
        // 以自身的水平轴进行旋转
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
