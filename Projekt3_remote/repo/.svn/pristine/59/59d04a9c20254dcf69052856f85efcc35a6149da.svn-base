using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prankster : Interactable
{
    public bool spokenTo;

    // Start is called before the first frame update
    void Start()
    {
        spokenTo = false;
    }

    public override void Interact()
    {
        if (!spokenTo)
        {
            // TODO [Dialog] Dialog z kawalarzem
            Debug.Log("Dialog z kawalarzem");
            spokenTo = true;
        }
        else
        {
            Debug.Log("Zostaw mnie");
        }
    }

    public override void SecondaryInteraction()
    {
        // TODO [Dialog]
        Debug.Log("Moze sie coś od niego dowiem");
    }
}
