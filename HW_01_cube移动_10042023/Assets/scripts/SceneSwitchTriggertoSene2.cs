using UnityEngine;

public class SceneSwitchTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �������ʹ��"Player"��ǩ
        {
            // ʹ���Զ���� CustomSceneManager �л��� Scene2
            MyNamespace.MySceneManager.LoadScene("Scene2");
        }
    }
}
