using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for representing single node of grid
/// </summary>
public class Node {

    public bool walkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    public int gCost; //How far is to starting node
    public int hCost; //How far is to targe node

    public Node parent;

    public Node(bool _walkable, Vector3 _worldPos,int _gridX,int _gridY)
    {
        walkable = _walkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;

    }


    public int fCost
    {
        get { return gCost + hCost; }
  
    }


}
