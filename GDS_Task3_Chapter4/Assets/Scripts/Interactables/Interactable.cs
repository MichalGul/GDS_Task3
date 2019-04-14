using UnityEngine;

/// <summary>
/// Base abstract class responsible for interactions
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    public string interactableName;
    public float interactionDistance;
    private Transform playerPosition;
    private Tooltip toolTip;
    private MoveToClickInput playerMovementController;


    private void Awake()
    {
        toolTip = GameObject.Find("Tooltip").GetComponent<Tooltip>();
        playerMovementController = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveToClickInput>();
        UpdatePlayerPosition();
    }

    public virtual void Interact()
    {
        Debug.Log("The interactable:  has been clicked");
    }

    public virtual void SecondaryInteraction()
    {
        Debug.Log("Secondary interaction:  has been clicked");
    }


    private void OnMouseDown()
    {
        UpdatePlayerPosition();
             
            if (Vector3.Distance(playerPosition.position, transform.position) < interactionDistance)
            {
                Interact();
            }
            else //Order player to come to object
            {
                //Debug.Log("PODCHODZE!!!");
                Vector3 interactableDir = (transform.position - playerPosition.position).normalized;
                //Debug.Log("INTERACTION DIR: " + interactableDir);
                playerMovementController.ApproachInteractable(transform.position - 0.5f * (interactableDir * interactionDistance));
            }

    }

    // Handle right click action 
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1)) //Secondary interaction
        {
            SecondaryInteraction();
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
            Debug.Log("tooltip not created for interactable");
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
