using UnityEngine;

public enum PotionType
{
    None,
    Speed,
    Money
}
public enum RecourceType
{
    None,
    Wood
}

[CreateAssetMenu(fileName = "NewInventoryItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public enum EnumType { PotionType , RecourceType  }
    public EnumType chosenEnumType;

    public PotionType potionType;  
    public RecourceType recourceType;  
    
    public string itemName;    
    public int value;        
    public Sprite icon;   
    public GameObject itemPrefab;

    public string description;
}
