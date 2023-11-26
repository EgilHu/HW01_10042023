using UnityEngine;

public class GetMyBagInstance : MonoBehaviour
{
    void Awake()
    {
        // 获取背包管理器的实例
        InventoryManager backpackManager = InventoryManager.Instance;

        // 这里可以访问背包管理器的方法和属性
    }
}
