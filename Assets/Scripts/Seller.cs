using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
   public GameObject inventoryUi;
   public List<GameObject> items = new();
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         inventoryUi.SetActive(true);
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         inventoryUi.SetActive(false);
      }
   }
}
