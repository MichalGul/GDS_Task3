using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AngleSharp.Html.Parser;

public class basic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        //Create a (re-usable) parser front-end
        var parser = new HtmlParser();
        //Source to be pared
        var source = "<h1>Some example source</h1><p>This is a paragraph element";
        //Parse source to document
        var document = parser.ParseDocument(source);
        //Do something with document like the following
        Debug.Log(document.DocumentElement.OuterHtml);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
