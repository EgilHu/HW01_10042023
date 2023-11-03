using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SoundManager soundManager; // 用于引用 SoundManager

    private void Start()
    {
        // 获取 SoundManager 的实例
        soundManager = SoundManager.instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            // 在按下空格键或"W", "A", "S", "D"键之一时执行操作
            soundManager.PlayFootstepSound();
        }
    }
}
