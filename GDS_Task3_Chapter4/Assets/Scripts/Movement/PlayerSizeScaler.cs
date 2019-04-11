using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizeScaler : MonoBehaviour
{

    [Tooltip("Percentage screen height limit where scaling must begin (0 - 100")]
    public float screenHeightScalingLimit;

    [Tooltip("Character scaling speed (0 - 1")]
    public float scaleSpeed = 1;

    [Tooltip("Character scale down limit (0 - 1")]
    public float scaleLimit;
    
    private int scaleScreenPositionLimit;
    private float scaleFactor = 1f;
    // Start is called before the first frame update
    void Start()
    {

        scaleScreenPositionLimit = Mathf.RoundToInt(screenHeightScalingLimit/100 * Screen.height);

    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.WorldToScreenPoint(transform.position).y > scaleScreenPositionLimit)
        {
            scaleFactor = 1.0f - ((Camera.main.WorldToScreenPoint(transform.position).y - scaleScreenPositionLimit) / scaleScreenPositionLimit) * scaleSpeed;
            Debug.Log(scaleFactor);

            if (scaleFactor >= scaleLimit)
            {              
                transform.localScale = new Vector3( scaleFactor, scaleFactor, 0);
            }
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
