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
    }
}
