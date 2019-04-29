using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartendeInteract : Interactable
{
    [Tooltip("Item, ktorego trzeba uzyc na barmanie zeby kupić flaszke")]
    public Item itemRequiredToClickOn;
    // item required to unlock additional dialog
    [Tooltip("Item, który trzeba mieć, żeby odblokować dodatkowy dialog")]
    public Item itemRequiredToUnlockAdditionalIteraction;

    public Item bottleToBuy;
    public bool bottleBought = false;

    public bool saidEverything = false;


    public override void Interact()
    {
        if(GameManager.instance.itemPointerSelectedItem != null)
        {
            if (GameManager.instance.itemPointerSelectedItem.id == itemRequiredToClickOn.id)
            {
                // TODO!  [DIALOG] kupno butelki
                if (!bottleBought)
                {
                    Debug.Log("Kupienie butelki");
                    //GameManager.instance.selectedItem.UpdateItem(null);
                    //GameManager.instance.playerInventory.RemoveItem(itemRequiredToClickOn.id);
                    GameManager.instance.playerInventory.GiveItem(bottleToBuy);
                    bottleBought = true;
                    GameManager.instance.UpdatePointerSelectedItem();
                }
            }
            else
            {// TODO!  [DIALOG] bledny item
                Debug.Log("Zly item");
            }
        }
        else if(GameManager.instance.playerInventory.CheckIfItemInInventory(itemRequiredToUnlockAdditionalIteraction.id))
        {
            if (!saidEverything)
            {
                // TODO!  [DIALOG] Odblokowany dialog z barmanem
                Debug.Log("Dodatkowy dialog z barmanem");
                saidEverything = true;
                Debug.Log("Chyba czas zadzwonic zrozyc raport");
            }
            else
            {
                Debug.Log("Daj mi spokoj");
            }
        }
        else //zwykła interakcja
        {
            // TODO!  [DIALOG] zwykly dialog z barmanem
            Debug.Log("Dialog z barmanem");
        }


    }

    public override void SecondaryInteraction()
    {
        Debug.Log(secondaryInteractionComment);
    }

}
