using UnityEngine;

public class GyroscopeRotation : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // ��ת�ٶ�

    void Update()
    {
        // �������ˮƽ�������ת
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
