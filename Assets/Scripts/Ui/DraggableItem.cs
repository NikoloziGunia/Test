using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler , IPointerEnterHandler, IPointerExitHandler
{
    public Transform canvas;
    public GameObject tooltipPanel;
    public InventoryItem inventoryItem;

    public LayerMask characterLayer;
    public GameManager gameManager;
    public Transform originalParent;
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (inventoryItem.item == null) return;

        if (gameManager.character.items.Contains(gameObject))
        {
            gameManager.character.items.Remove(gameObject);
        }
        else if (gameManager.Seller.items.Contains(gameObject))
        {
            gameManager.Seller.items.Remove(gameObject);
        }

        originalParent = transform.parent;
        transform.SetParent(originalParent.root);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        
       

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, characterLayer))
        {
            CheckItemType(hit.collider.gameObject.GetComponent<Character>() , inventoryItem);
        }
        else  if (transform.parent == canvas)
        {
            var itemWorld = Instantiate(inventoryItem.item.itemPrefab, Vector3.zero, Quaternion.identity);
            itemWorld.name = inventoryItem.item.itemName;
            Destroy(gameObject);
        }
    }

    void CheckItemType(Character character , InventoryItem inventoryItem)
    {
        if(inventoryItem.item.chosenEnumType == Item.EnumType.PotionType)
        {
            if (inventoryItem.item.potionType == PotionType.Money)
            {
                character.money += 300;
                gameManager.UpdateMoney();
                gameManager.character.moneyGain.Play();
            }
            else if (inventoryItem.item.potionType == PotionType.Speed)
            {
                character.characterMovement.moveSpeed += 1.5f;
                gameManager.character.speedGain.Play();
            }
            Destroy(gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipPanel.SetActive(false);
    }
}