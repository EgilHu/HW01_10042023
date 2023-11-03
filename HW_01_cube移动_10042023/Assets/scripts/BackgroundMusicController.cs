using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneScript : MonoBehaviour
{
    private void Start()
    {
        // 在场景开始时播放背景音乐
        PlayBackgroundMusicForCurrentScene();
    }

    private void PlayBackgroundMusicForCurrentScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SoundManager.instance.PlayBackgroundMusicForScene(sceneIndex);
    }

    // 示例：切换场景并播放相应的背景音乐
    public void LoadNextScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
        PlayBackgroundMusicForCurrentScene();
    }
}
