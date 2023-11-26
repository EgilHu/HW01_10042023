namespace MyNamespace
{
    using System;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class MySceneManager : MonoBehaviour
    {
        private static MySceneManager instance;
        //public InventoryDataManager inventoryDataManager; // ����ͨ�� Inspector ���ָ��


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

        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            ////SceneManager.LoadScene("Scene2", LoadSceneMode.Single);
        }

        //private void Start()
        //{
        //    // ��ʼ�����ݣ������δ��ʼ����
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

            // ����������ʱ�������¼�֪ͨ������
            OnSceneSwitchCountChanged?.Invoke();
        }

    }

}
