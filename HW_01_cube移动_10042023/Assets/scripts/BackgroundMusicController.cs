using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneScript : MonoBehaviour
{
    private void Start()
    {
        // �ڳ�����ʼʱ���ű�������
        PlayBackgroundMusicForCurrentScene();
    }

    private void PlayBackgroundMusicForCurrentScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SoundManager.instance.PlayBackgroundMusicForScene(sceneIndex);
    }

    // ʾ�����л�������������Ӧ�ı�������
    public void LoadNextScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
        PlayBackgroundMusicForCurrentScene();
    }
}
