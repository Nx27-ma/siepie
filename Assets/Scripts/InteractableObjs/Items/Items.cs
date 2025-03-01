using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
    public string itemName;
    public int itemID;
    public Sprite icon;

    public Item(string name, int id, Sprite icon = null)
    {
        this.itemName = name;
        this.itemID = id;
        this.icon = icon;
        
    }
}
