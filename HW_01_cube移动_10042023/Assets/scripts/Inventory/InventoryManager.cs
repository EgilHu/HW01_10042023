using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;

    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
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
