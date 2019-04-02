using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotationReactor : SwitchStateReactor
{

    public float activeAngle;
    public float inactiveAngle;

    public override void React()
    {
        if (switcherToObserve.State)
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -90));

        }
    }

}
