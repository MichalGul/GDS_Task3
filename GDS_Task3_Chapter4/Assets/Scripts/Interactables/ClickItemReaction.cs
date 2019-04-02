using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickItemReaction : Interactable
{
    public Item itemRequiredToClickOn;

    public override void Interact()
    {
        if (GameManager.instance.itemPointerSelectedItem.id == itemRequiredToClickOn.id)
        {
            Debug.Log("YOU USED CORRECT ITEM ON THIS");
            GameManager.instance.selectedItem.UpdateItem(null);
            GameManager.instance.playerInventory.RemoveItem(itemRequiredToClickOn.id);
        }
        else
        {
            Debug.Log("You need to use " + itemRequiredToClickOn.title + " to use that!");
        }
    }
}
