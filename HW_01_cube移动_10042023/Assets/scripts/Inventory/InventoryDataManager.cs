using System.Collections.Generic;
using UnityEngine;

public class InventoryDataManager : MonoBehaviour
{
    private static InventoryDataManager instance;

    public static bool isItemCollected { get; private set; }

    // 数据
    public List<Item> savedItems = new List<Item>();

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

        isItemCollected = PlayerPrefs.GetInt("ItemCollected", 0) == 1;
    }

    // 初始化数据的方法
    private void InitializeData()
    {
        // 在这里添加需要初始化的数据
    }

    public static void SetItemCollected(bool collected)
    {
        isItemCollected = collected;
        PlayerPrefs.SetInt("ItemCollected", collected ? 1 : 0);
        PlayerPrefs.Save();
    }

    private static bool isInitialized = false;
}


