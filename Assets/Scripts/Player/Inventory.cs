using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public List<Item> itemList;

    public void AddItem(Item item) // Use this if you want to add an item - David
    {
        itemList.Add(item);
    }

    public void RemoveItem(Item item) // Use this to remove an item
    {
        itemList.Remove(item);
    }

    public bool HasItemID(int ItemID) // Use this if you want to check for specific itemID 
    {
        return itemList.Any(Item => Item.itemID == ItemID);
    }


}
