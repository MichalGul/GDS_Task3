using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject selectedItem; //or UI item
    public Inventory playerInventory;
    //This field will be used to check using item on other interactables
    public Item itemPointerSelectedItem;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }




    public void UpdatePointerSelectedItem()
    {
        itemPointerSelectedItem = selectedItem.GetComponent<UIItem>().selectedItem.item;
    }



}
