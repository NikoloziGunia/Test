using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Item item; 
    public Image itemIcon;
    public TMP_Text description;

    private void Start()
    {
        SetItem(item);
    }

    public void SetItem(Item newItem)
    {
        item = newItem;

        if (item != null)
        {
            itemIcon.sprite = item.icon;
            itemIcon.enabled = true;
            description.text = item.description;
        }
        else
        {
            itemIcon.enabled = false; 
        }
    }
}
