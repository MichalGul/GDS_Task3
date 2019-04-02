using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    private Image spriteImage;
    public UIItem selectedItem;

    //private ItemTooltip toolTip;

    private void Awake()
    {
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>(); //znajdz obiekt i wez jego komponent, wykorzystane do drag and drop
        //toolTip = GameObject.Find("Tooltip").GetComponent<ItemTooltip>();
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
        //selectedItem.UpdateItem(null);
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if (this.item != null)
        {
            // Debug.Log(item.icon);
            spriteImage.color = Color.white; //set alpha 1 -> show icon
            spriteImage.sprite = item.inventoryIcon;
        }
        else
        {
            
            spriteImage.color = Color.clear; //set alpha to zero
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.item != null) // 
        {  //selectedItem _. item ktory dragujemy
            if (selectedItem.item != null) // if dragin and item clicked exists we need to clone that and replace
            {
                //Clone item
                Item clone = new Item(selectedItem.item);//copy draging item
                selectedItem.UpdateItem(this.item);//item that i want put to slot
                GameManager.instance.UpdatePointerSelectedItem();
                UpdateItem(clone);
            }
            else if (selectedItem.item == null || selectedItem.item.id == 0) //jezeli nic nie dragujemy i klikamy na obiekt
            {
                
                selectedItem.UpdateItem(this.item);
                GameManager.instance.UpdatePointerSelectedItem();           
                UpdateItem(null);
            }

        }
        else if (selectedItem.item != null) //jezeli cos draguje a slot jest pusty
        {
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
            GameManager.instance.UpdatePointerSelectedItem();

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //if (this.item != null)
        //{
        //    toolTip.GenerateTooltip(this.item);
        //}
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //toolTip.gameObject.SetActive(false);
    }
}
