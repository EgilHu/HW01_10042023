using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string targetSceneName; // 目标场景的名称

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 假设玩家使用"Player"标签
        {
            SceneManager.LoadScene(targetSceneName); // 加载目标场景
        }
    }
}
