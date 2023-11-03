using UnityEngine;

public class SceneSwitchBackTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �������ʹ��"Player"��ǩ
        {
            // ʹ���Զ���� CustomSceneManager �л��� Scene1
            MyNamespace.MySceneManager.LoadScene("Scene1");
        }
    }
}
