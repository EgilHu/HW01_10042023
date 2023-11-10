using UnityEngine;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip[] backgroundMusic;  // �������ڴ洢��ͬ�����ı�������
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
        // ��ȡ�Ӷ���� AudioSource ���
       
        SceneManager.sceneLoaded += OnSceneLoaded; // ���ĳ��������¼�
        PlayBackgroundMusicForScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // �������������ʱ�����ݳ����������л���������
        PlayBackgroundMusicForScene(scene.buildIndex);
    }

    public void PlayBackgroundMusicForScene(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < backgroundMusic.Length)
        {
            // ���� BackgroundMusicPlayer ����Ƶ����������
            backgroundMusicPlayer.clip = backgroundMusic[sceneIndex];
            backgroundMusicPlayer.Play();
            Debug.Log(sceneIndex);
        }
    }

    public void PlayFootstepSound()
    {
        // ���ŽŲ�����Ч
        footstepSoundPlayer.PlayOneShot(footstepSound);
    }
}
