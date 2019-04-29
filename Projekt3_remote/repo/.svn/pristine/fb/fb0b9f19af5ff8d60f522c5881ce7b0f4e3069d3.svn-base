using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitInteractable : Interactable
{
    public TelephoneInfo telephoneWatcher;


    public override void Interact()
    {
       if (!telephoneWatcher.reported)
        {
            // TODO Dialog ze soba
            Debug.Log("Nie dowiedzialem sie wszystkiego / Raport");
        }
        else
        {
            // TODO Dialog ze soba -> pora jechać na stację
            GameManager.instance.LoadNextLevel();

        }
    }

}
