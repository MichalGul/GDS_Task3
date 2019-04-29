using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoungWorker : Interactable
{

    public Prankster prankster;
    public bool offended;

    public delegate void OnStateChange();
    public event OnStateChange StateChange;

    private MoveToExit moveToExit;

    public override void Interact()
    {
        if(!prankster.spokenTo)
        {
            //TODO [Dialog] Dojechanie mlodemu
            Debug.Log("Dojechanie, młodemu");

            offended = true;
            StateChange?.Invoke();

            //TODO po dialogu dojechania
            moveToExit.GoOut();
          
        }
        else
        {
            //TODO [Dialog] Zwykly dialog
            Debug.Log("Dialog zwykly");
        }
        
    }

    void Start()
    {
        moveToExit = GetComponent<MoveToExit>();
        offended = false;
    }


}
