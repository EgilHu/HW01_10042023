using UnityEngine;

public class SceneSwitchBackTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 假设玩家使用"Player"标签
        {
            // 使用自定义的 CustomSceneManager 切换回 Scene1
            MyNamespace.MySceneManager.LoadScene("Scene1");
        }
    }
}
