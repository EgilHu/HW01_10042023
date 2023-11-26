using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    // ��־������Ƿ��Ѿ���ʼ��������
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

        // ��ʼ������
        if (!isInitialized)
        {
            InitializeData();
            isInitialized = true;
        }

        int itemCollectedValue = PlayerPrefs.GetInt("ItemCollected", -1);

        if (itemCollectedValue == 1)
        {
            Debug.Log("Item has been collected!");

            GameObject item = GameObject.FindWithTag("Item"); // ʹ�ñ�ǩ
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
        // �����������Ҫ��ʼ��������
    }
}
