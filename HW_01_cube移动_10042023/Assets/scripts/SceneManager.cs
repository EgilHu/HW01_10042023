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
        }

        public int sceneSwitchCount = 0;
        // 声明一个事件以在场景切换次数发生变化时通知订阅者
        public event Action OnSceneSwitchCountChanged;
        private void Start()
        {
            // 订阅SceneManager的SceneLoaded事件
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        public int GetSceneSwitchCount()
        {
            // 返回场景切换次数
            return sceneSwitchCount;

        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            sceneSwitchCount++;

            // 当场景加载时，触发事件通知订阅者
            OnSceneSwitchCountChanged?.Invoke();
        }

    }

}
