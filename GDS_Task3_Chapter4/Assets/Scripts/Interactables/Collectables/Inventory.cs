using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> playerItems = new List<Item>();
    public UIInventory inventoryUI;


    
    public void GiveItem(int id)
    {
        
    }

    public void GiveItem(string itemName)
    {

    }
    public void GiveItem(Item itemToGive)
    {
        playerItems.Add(itemToGive);
        inventoryUI.AddNewItem(itemToGive);
    }

    public Item CheckForItem(int id)
    {
        return playerItems.Find(item => item.id == id);
    }

    public bool CheckIfItemInInventory(int itemId)
    {
        Item foundItem = playerItems.Find(item => item.id == itemId);
        return foundItem != null;

    }


    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);
        if (itemToRemove != null)
        {
            playerItems.Remove(itemToRemove);
            //inventoryUI.RemoveItem(itemToRemove); ! cause problem when you use item on object - tries to delete UI Item that no longer exists
            //Debug.Log("Removed: " + itemToRemove.title);
        }
    }




}
