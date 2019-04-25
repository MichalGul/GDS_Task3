using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private Text tooltipText;

    // Start is called before the first frame update
    void Start()
    {
        tooltipText = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
    }

    public void GenerateTooltip(Item item) //this will be called when hovering over UI item or item in world or object in world
    {
        string tooltip = string.Format("<b>{0}</b>", item.title);

        tooltipText.text = tooltip;
        gameObject.SetActive(true);

    }

    public void GenerateTooltip(string interactableName) 
    {
        string tooltip = string.Format("<b>{0}</b>", interactableName);

        tooltipText.text = tooltip;
        gameObject.SetActive(true);

    }

}
