using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Base abstract class responsible for interactions
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    public string interactableName;
    public float interactionDistance;
    private Transform playerPosition;
    private Tooltip toolTip;

    private void Awake()
    {
        toolTip = GameObject.Find("Tooltip").GetComponent<Tooltip>();
        UpdatePlayerPosition();
    }

    public virtual void Interact()
    {
        Debug.Log("The interactable:  has been clicked");
    }

    private void OnMouseDown()
    {
        UpdatePlayerPosition();

        if (Vector3.Distance( playerPosition.position, transform.position) < interactionDistance)
        {
            Interact();
        }

    }

    private void OnMouseEnter()
    {
        if (toolTip)
        {
            toolTip.GenerateTooltip(interactableName);
        }
        else
        {
            Debug.Log("tooltip not created for interactgable");
        }

    }
    private void OnMouseExit()
    {
        if (toolTip)
        {
            toolTip.gameObject.SetActive(false);
        }
    }

    private void UpdatePlayerPosition()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

 
}
