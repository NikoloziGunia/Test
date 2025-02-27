using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
   public Inventory inventory;
   public CharacterMovement characterMovement;
   public int money;
   public ParticleSystem moneyGain;
   public ParticleSystem speedGain;
   public List<GameObject> items = new();

   
   private void OnCollisionEnter(Collision collision) // pickup item 
   {
      if (collision.gameObject.CompareTag("Item"))
      {
         PickUpItem(collision.gameObject.GetComponent<InventoryItem>());
      }
   }

   void PickUpItem(InventoryItem item)
   {
      inventory.items.Add(item);
      inventory.CreateSlot(item);
      item.gameObject.SetActive(false);
   }
   
}
