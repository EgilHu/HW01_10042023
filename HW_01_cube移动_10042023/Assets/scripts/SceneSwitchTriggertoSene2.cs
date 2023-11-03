using UnityEngine;

public class SceneSwitchTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 假设玩家使用"Player"标签
        {
            // 使用自定义的 CustomSceneManager 切换到 Scene2
            MyNamespace.MySceneManager.LoadScene("Scene2");
        }
    }
}
