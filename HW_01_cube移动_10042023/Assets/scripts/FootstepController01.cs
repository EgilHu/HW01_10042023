using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SoundManager soundManager; // �������� SoundManager

    private void Start()
    {
        // ��ȡ SoundManager ��ʵ��
        soundManager = SoundManager.instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            // �ڰ��¿ո����"W", "A", "S", "D"��֮һʱִ�в���
            soundManager.PlayFootstepSound();
        }
    }
}
