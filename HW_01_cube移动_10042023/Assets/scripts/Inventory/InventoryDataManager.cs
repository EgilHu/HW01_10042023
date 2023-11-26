using System.Collections.Generic;
using UnityEngine;

public class InventoryDataManager : MonoBehaviour
{
    private static InventoryDataManager instance;

    public static bool isItemCollected { get; private set; }

    // ����
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

        // ��ʼ������
        if (!isInitialized)
        {
            InitializeData();
            isInitialized = true;
        }

        isItemCollected = PlayerPrefs.GetInt("ItemCollected", 0) == 1;
    }

    // ��ʼ�����ݵķ���
    private void InitializeData()
    {
        // �����������Ҫ��ʼ��������
    }

    public static void SetItemCollected(bool collected)
    {
        isItemCollected = collected;
        PlayerPrefs.SetInt("ItemCollected", collected ? 1 : 0);
        PlayerPrefs.Save();
    }

    private static bool isInitialized = false;
}


