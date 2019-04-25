using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    public string title;
    public string description;
    public string interactionComment;
    public Sprite inventoryIcon;
    public Sprite worldIcon;

    public Item()
    {

    }

    public Item(int id, string title, string description, string interComm , Sprite inventoryIcon = null, Sprite worldIcon = null)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.interactionComment = interComm;
        this.inventoryIcon = inventoryIcon;
        this.worldIcon = worldIcon;
    }

    public Item (Item item)
    {
        id = item.id;
        title = item.title;
        description = item.description;
        inventoryIcon = item.inventoryIcon;
        interactionComment = item.interactionComment;
        worldIcon = item.worldIcon;
    }


}
