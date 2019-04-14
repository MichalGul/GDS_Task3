using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRequire : Interactable
{
    public Item itemRequiredToInteract;

    public override void Interact()
    {
        if (GameManager.instance.playerInventory.CheckIfItemInInventory(itemRequiredToInteract.id))
        {
            base.Interact();
        }
        else
        {
            Debug.Log("You need to have " + itemRequiredToInteract.title + " to use that!");
        }
    }

    public override void SecondaryInteraction()
    {
        base.SecondaryInteraction();
    }
}
