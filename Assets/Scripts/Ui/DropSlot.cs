using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour , IDropHandler
{
    public bool isMine;
    public Character character;
    public GameManager gameManager;
    
    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem draggedItem = eventData.pointerDrag?.GetComponent<DraggableItem>();

        if (draggedItem != null)
        {
            if (isMine)
            {
                if (draggedItem.originalParent.gameObject != gameObject) //buy
                {
                    
                    if (character.money >= draggedItem.inventoryItem.item.value)
                    {
                        character.money -= draggedItem.inventoryItem.item.value;
                        draggedItem.transform.SetParent(transform); 
                        draggedItem.transform.localPosition = Vector3.zero;
                        
                        gameManager.UpdateMoney();
                        gameManager.character.items.Add(draggedItem.gameObject);

                    }
                    else
                    {
                        Debug.Log("Cant buy");
                        draggedItem.transform.SetParent(draggedItem.originalParent); 
                        draggedItem.transform.localPosition = Vector3.zero;
                    }
                    
                }
                else
                {
                    Debug.Log("VAR");
                    draggedItem.transform.SetParent(transform); 
                    draggedItem.transform.localPosition = Vector3.zero;
                    gameManager.character.items.Add(draggedItem.gameObject);
                }
                
            }
            else
            {
                if (draggedItem.originalParent.gameObject != gameObject) //sell
                {
                    character.money += draggedItem.inventoryItem.item.value;
                    
                    draggedItem.transform.SetParent(transform); 
                    draggedItem.transform.localPosition = Vector3.zero;
                    
                    gameManager.UpdateMoney();
                }
                
                if (draggedItem.originalParent.gameObject == gameObject)
                {
                    draggedItem.transform.SetParent(transform); 
                    draggedItem.transform.localPosition = Vector3.zero;
                }
                gameManager.Seller.items.Add(draggedItem.gameObject);
            }
        }
    }
}
