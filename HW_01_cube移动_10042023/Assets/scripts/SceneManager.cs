namespace MyNamespace
{
    using System;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class MySceneManager : MonoBehaviour
    {
        private static MySceneManager instance;

        public static MySceneManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<MySceneManager>();
                    if (instance == null)
                    {
                        GameObject singleton = new GameObject("MySceneManager");
                        instance = singleton.AddComponent<MySceneManager>();
                    }
                }
                return instance;
            }
        }

        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            sceneSwitchCount++;
        }

        public static int sceneSwitchCount = 0;
        // ����һ���¼����ڳ����л����������仯ʱ֪ͨ������
        public event Action OnSceneSwitchCountChanged;
        private void Start()
        {
            // ����SceneManager��SceneLoaded�¼�
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        public int GetSceneSwitchCount()
        {
            // ���س����л�����
            return sceneSwitchCount;

        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            //sceneSwitchCount++;

            // ����������ʱ�������¼�֪ͨ������
            OnSceneSwitchCountChanged?.Invoke();
        }

    }

}
