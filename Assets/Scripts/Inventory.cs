using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items;
    public InventoryItem slotPrefab;
    public Transform inventory;
    public Transform canvas;
    
    public void CreateSlot(InventoryItem newitem) // after pick up for ui 
    {
        var newSlot = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity);
        newSlot.transform.SetParent(inventory.GetChild(0));
        newSlot.item = newitem.item;
        newSlot.gameObject.GetComponent<DraggableItem>().canvas = canvas;
    }

    public void LoadItems(List<InventoryItem> otherItems , Transform otherInventory) // for seller inventory ui
    {
        foreach (var item in otherItems)
        {
            var newSlot = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity);
            newSlot.transform.SetParent(otherInventory.GetChild(0));
            newSlot.gameObject.GetComponent<DraggableItem>().canvas = canvas;
            newSlot.item = item.item;
        }
    }
    
}
