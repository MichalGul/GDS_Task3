using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Switcher class responsible for broadcasting its state to all listeners
/// </summary>
public class Switcher : Interactable
{

    public bool State;
    //setup event
    public delegate void OnStateChange();
    public event OnStateChange StateChange ;

    public override void Interact()
    {
        //change state
        State = !State;

        //broadcast event to all listeners (if exists)
        StateChange?.Invoke();
    }

}
