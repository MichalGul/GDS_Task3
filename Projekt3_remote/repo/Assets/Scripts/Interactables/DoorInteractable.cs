using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : Interactable
{

    public Item itemRequiredToInteract;

    public override void Interact()
    {
        if (GameManager.instance.playerInventory.CheckIfItemInInventory(itemRequiredToInteract.id))
        {
            // TODO! zapisanie posiadanych przedmiotów i przejście do sceny baru
            Debug.Log("Wchodze do baru");
            GameManager.instance.LoadNextLevel();
        }
        else
        {
            // TODO! Bohater mówi do siebie, że zapomniał portfela [DIALOG]
            Debug.Log("Zapomniałem porftela ");
            
        }
    }

    public override void SecondaryInteraction()
    {
        // TODO! [DIALOG] - komentarz o barze
        base.SecondaryInteraction();
    }

}
