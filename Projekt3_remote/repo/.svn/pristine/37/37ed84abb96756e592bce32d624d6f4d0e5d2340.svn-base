using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneInfo : ClickItemReaction
{
    public BartendeInteract barman;
    public bool reported;

    public override void Interact()
    {
        if (GameManager.instance.itemPointerSelectedItem != null)
        {
            if (GameManager.instance.itemPointerSelectedItem.id == itemRequiredToClickOn.id)
            {
                if (barman.saidEverything) //  lub robotnik wszystko wyspiewal
                {
                    // TODO!  [DIALOG] Raport przez telefon
                    Debug.Log("Zdaje Raport przez telefon, trzeba jechać na stacje");
                    reported = true;
                    //GameManager.instance.selectedItem.UpdateItem(null);
                    //GameManager.instance.playerInventory.RemoveItem(itemRequiredToClickOn.id);
                }
                else
                {
                    // TODO!  [DIALOG] Nie ma po co dzwonic
                    Debug.Log("Nic nie wiem");

                }

            }
        }
        else
        {
            // TODO!  [DIALOG] Zaplacic trzeba
            Debug.Log("Trzeba zaplacic");
        }
    }

    private void Start()
    {
        reported = false;
    }

}
