using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    // 标志：检查是否已经初始化过数据
    private static bool isInitialized = false;

    void Awake()
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

        // 初始化数据
        if (!isInitialized)
        {
            InitializeData();
            isInitialized = true;
        }

        int itemCollectedValue = PlayerPrefs.GetInt("ItemCollected", -1);

        if (itemCollectedValue == 1)
        {
            Debug.Log("Item has been collected!");

            GameObject item = GameObject.FindWithTag("Item"); // 使用标签
            if (item != null)
            {
                Destroy(item); 
            }
        }
        else if (itemCollectedValue == -1)
        {
            Debug.Log("Item has not been collected.");
        }
        else
        {
            Debug.Log("Invalid value for ItemCollected.");
        }
    }

    private void InitializeData()
    {
        // 在这里添加需要初始化的数据
    }
}
