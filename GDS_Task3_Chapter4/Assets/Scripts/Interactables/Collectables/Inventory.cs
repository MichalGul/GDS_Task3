using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> playerItems = new List<Item>();
    



    public void GiveItem(int id)
    {
        
    }

    public void GiveItem(string itemName)
    {

    }
    public void GiveItem(Item itemToGive)
    {
        playerItems.Add(itemToGive);

    }


    public Item CheckForItem(int id)
    {
        return new Item();
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);
        if (itemToRemove != null)
        {
            playerItems.Remove(itemToRemove);
            //inventoryUI.RemoveItem(itemToRemove);
            //Debug.Log("Removed: " + itemToRemove.title);
        }
    }




}
