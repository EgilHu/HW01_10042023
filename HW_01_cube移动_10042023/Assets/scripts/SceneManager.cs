namespace MyNamespace
{
    using System;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class MySceneManager : MonoBehaviour
    {
        private static MySceneManager instance;
        //public InventoryDataManager inventoryDataManager; // 可以通过 Inspector 面板指定


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
        // 声明一个事件以在场景切换次数发生变化时通知订阅者
        public event Action OnSceneSwitchCountChanged;

        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            ////SceneManager.LoadScene("Scene2", LoadSceneMode.Single);
        }

        //private void Start()
        //{
        //    // 初始化数据（如果尚未初始化）
        //    if (!InventoryDataManager.isInitialized)
        //    {
        //        inventoryDataManager.InitializeData();
        //        InventoryDataManager.isInitialized = true;
        //    }
        //}


        public int GetSceneSwitchCount()
        {
            return sceneSwitchCount;
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            //sceneSwitchCount++;

            // 当场景加载时，触发事件通知订阅者
            OnSceneSwitchCountChanged?.Invoke();
        }

    }

}
