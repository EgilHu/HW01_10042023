using UnityEngine;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip[] backgroundMusic;  // 数组用于存储不同场景的背景音乐
    public AudioClip footstepSound;

    private AudioSource backgroundMusicPlayer;
    private AudioSource footstepSoundPlayer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        backgroundMusicPlayer = transform.Find("BackgroundMusic").GetComponent<AudioSource>();
        footstepSoundPlayer = transform.Find("Footstep").GetComponent<AudioSource>();
    }

    private void Start()
    {
        // 获取子对象的 AudioSource 组件
       
        SceneManager.sceneLoaded += OnSceneLoaded; // 订阅场景加载事件
        PlayBackgroundMusicForScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 当场景加载完成时，根据场景的索引切换背景音乐
        PlayBackgroundMusicForScene(scene.buildIndex);
    }

    public void PlayBackgroundMusicForScene(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < backgroundMusic.Length)
        {
            // 设置 BackgroundMusicPlayer 的音频剪辑并播放
            backgroundMusicPlayer.clip = backgroundMusic[sceneIndex];
            backgroundMusicPlayer.Play();
            Debug.Log(sceneIndex);
        }
    }

    public void PlayFootstepSound()
    {
        // 播放脚步声音效
        footstepSoundPlayer.PlayOneShot(footstepSound);
    }
}
