using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string targetSceneName; // Ŀ�곡��������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �������ʹ��"Player"��ǩ
        {
            SceneManager.LoadScene(targetSceneName); // ����Ŀ�곡��
        }
    }
}
