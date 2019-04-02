using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clas that holds an item that player can take
/// </summary>
public class Collector : Interactable
{
    public Item item;
    public Inventory playerInventory; //! not good practice, change that
    public bool itemTaken;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer && item.worldIcon)
        {
            spriteRenderer.sprite = item.worldIcon;
        }
    }

    // Start is called before the first frame update
    public override void Interact()
    {
        if (item != null && !itemTaken)
        {
            playerInventory.GiveItem(item);
            itemTaken = true;
            gameObject.SetActive(false);
        }
        
    }
}
