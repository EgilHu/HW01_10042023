using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject myBag;
    bool isOpen;

    private void Update()
    {
        OpenMyBag();
    }

    void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            myBag.SetActive(isOpen);
        }
    }
}
