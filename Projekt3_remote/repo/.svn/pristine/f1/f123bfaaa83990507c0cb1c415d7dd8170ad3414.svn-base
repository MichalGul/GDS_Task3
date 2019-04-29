using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoboInteractable : Interactable
{
    public OldWorkerInteract oldWorker;
    public YoungWorker youngWorker;

    public Item hoboBottle;
    public bool drunk;

    public override void Interact()
    {
        if (oldWorker.offended)
        {
            //TODO [Dialog] Rozmowa z menelem po obrazeniu starego robotnika
            Debug.Log("Obraziles robotnika");

            //TODO [Dialog] o jaka dziwna butelka
            GameManager.instance.playerInventory.GiveItem(hoboBottle);
            Debug.Log("Dziwna butelka");

        }
        else if (drunk)
        {
            //TODO [Dialog] mozna okraść robotnika
            Debug.Log("Wyglada na pijanego w sztok, mozna go okraść");
            GameManager.instance.playerInventory.GiveItem(hoboBottle);

            //TODO [Dialog] o jaka dziwna butelka
            Debug.Log("Dziwna butelka");
        }
        else
        {
            //TODO [Dialog] zwykly dzialog, przyjecie zakladu
            Debug.Log("Przyjecie zakladu");
        }

    }
    void Start()
    {
        drunk = false;

        youngWorker.StateChange += React;
    }

    public void React()
    {
        drunk = true;
    }
}
