using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

public static InventoryManager Instance
{
    get
    {
        if (instance == null)
        {
            instance = FindObjectOfType<InventoryManager>();

            if (instance == null)
            {
                GameObject go = new GameObject("InventoryManager");
                instance = go.AddComponent<InventoryManager>();
                DontDestroyOnLoad(go);
            }
        }

        return instance;
    }
}


    public Inventory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    private void OnEnable()
    {
        RefreshItem();
    }

    public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform);
        //Debug.Log("New slot position: " + newItem.transform.position);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
        Canvas.ForceUpdateCanvases();
    }

    public static void RefreshItem()
    {
        // Destroy all existing slots
        foreach (Transform child in instance.slotGrid.transform)
        {
            Destroy(child.gameObject);
        }

        // Create new slots for each item in the inventory
        foreach (Item item in instance.myBag.itemList)
        {
            CreateNewItem(item);
        }
    }

}
