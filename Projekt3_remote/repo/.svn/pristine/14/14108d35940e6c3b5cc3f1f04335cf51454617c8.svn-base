using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base abstract class responsible for interactions
/// </summary>
public abstract class Interactable : MonoBehaviour
{

    public float interactionDistance;
    private Transform playerPosition;

    private void Awake()
    {
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

    private void UpdatePlayerPosition()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

}
