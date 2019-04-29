using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldWorkerInteract : Interactable
{
    public YoungWorker youngWorker;
    private MoveToExit moveToExit;

    public bool informationGiven;
    public bool offended;

    public delegate void OnStateChange();
    public event OnStateChange StateChange;

    [Tooltip("Item, ktorego trzeba uzyc na pracowniku zeby zdobyć informacje")]
    public Item itemRequiredToClickOn;

    public override void Interact()
    {
        if (GameManager.instance.itemPointerSelectedItem != null)
        {
            if (GameManager.instance.itemPointerSelectedItem.id == itemRequiredToClickOn.id)
            {

                if (youngWorker.offended)
                {
                    // TODO!  [DIALOG] dialog info od starego robotnika
                    Debug.Log("Dostajemy Informacje od starego robotnika");
                    GameManager.instance.selectedItem.UpdateItem(null);
                    GameManager.instance.playerInventory.RemoveItem(itemRequiredToClickOn.id);
                    GameManager.instance.UpdatePointerSelectedItem();
                    informationGiven = true;
                }
                else
                {
                    // TODO!  [DIALOG] Nie dojechalismy młodego
                    Debug.Log("Nie przyjmuje butelki");
                }
            }
            else
            {
                // TODO!  [DIALOG] bledny item
                Debug.Log("Zly item");
            }

        }
        else
        {
            if (!youngWorker.offended && youngWorker.prankster.spokenTo)
            {
                // TODO!  [DIALOG] Kontrowanie pierdolenia starego robotnika
                Debug.Log("Kontra gadania i opuszcza bar");
                offended = true;
                StateChange?.Invoke();

                //TODO po dialogu obrażenia, wychodzi z baru
                print(moveToExit);
                moveToExit.GoOut();
            }
            else
            {
                if (!informationGiven)
                {
                    // TODO!  [DIALOG] Zwykly dialog
                    Debug.Log("Chce mu sie pic");
                }
                else
                {
                    // TODO!  [DIALOG] Wszystko
                    Debug.Log("Dowiedzieliśmy się wszystkiego");
                }

            }

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        moveToExit = GetComponent<MoveToExit>();
        offended = false;
    }

}
