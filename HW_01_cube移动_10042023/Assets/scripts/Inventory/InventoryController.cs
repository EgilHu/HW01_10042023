using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject myBag;
    bool isOpen;
    public Transform playerTransform;

    void Update()
    {
        OpenMyBag();

        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                Debug.Log($"Number {i} key pressed");
                DropItemFromSlot(i - 1); // µ÷ÕûÎª 0-based index
            }
        }
    }

    void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            myBag.SetActive(isOpen);
        }
    }



    bool IsValidSlotIndex(int slotIndex)
    {
        return slotIndex >= 0 && slotIndex < InventoryManager.instance.myBag.itemList.Count;
    }

    void DropItemInScene(Item item, int slotIndex)
    {
        Vector3 dropPosition = playerTransform.position + playerTransform.forward * 2f - new Vector3(0f, 1f, 0f);

        GameObject droppedItem = Instantiate(item.itemPrefab, dropPosition, Quaternion.identity);

        if (item.itemHeld > 1)
        {
            item.itemHeld--;
        }
        else
        {
            InventoryManager.instance.myBag.itemList.RemoveAt(slotIndex);
        }
        InventoryManager.RefreshItem();
    }


    void DropItemFromSlot(int slotIndex)
    {
        if (IsValidSlotIndex(slotIndex))
        {
            Item itemToDrop = InventoryManager.instance.myBag.itemList[slotIndex];

            if (itemToDrop != null)
            {
                DropItemInScene(itemToDrop, slotIndex);
            }
        } 
    }

}
