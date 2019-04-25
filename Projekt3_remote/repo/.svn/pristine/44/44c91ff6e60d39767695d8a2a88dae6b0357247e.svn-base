using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //our UI item
    public UIItem selectedItem; 

    public Inventory playerInventory;

    //This field will be used to check using item on other interactables
    public Item itemPointerSelectedItem;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //Set to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
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
