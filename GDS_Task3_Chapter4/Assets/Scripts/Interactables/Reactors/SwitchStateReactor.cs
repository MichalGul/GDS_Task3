using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Abstract class responsible for reacting on certain objects state(s)
/// </summary>
public abstract class SwitchStateReactor : MonoBehaviour
{
    public Switcher switcherToObserve; //? or list/array of switchers

    private void Awake()
    {
        //Assign event listener to switcher event broadcaster
        switcherToObserve.StateChange += React;
    }

    //React on observer switcher state change
    public virtual void React()
    {
        Debug.Log("Reacting on switcher: " + switcherToObserve.interactableName + " state change");
    }
}
