using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;

    [Tooltip("Draw helper grid in scene view")]
    public bool drawGrid;
    Node[,] grid;

    //Diameter of single node
    float nodeDiameter;
    //Size of the grid
    int gridSizeX;
    int gridSizeY;

    //public Transform Player;
   
    void Awake()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();

    }
    /// <summary>
    /// Create grid based on grid and node sizes
    /// </summary>
    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        //Start with bottom left world corner
        //Owner shoudl be int the middle of the screen
        Vector3 worldBottomLeftCorner = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2;


        for (int x = 0; x < gridSizeX; x++){
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeftCorner + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.up * (y * nodeDiameter + nodeRadius);
                //Collision check for the point (if walkable)
                //bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask));
                bool walkable = !(Physics2D.OverlapCircle(new Vector2(worldPoint.x, worldPoint.y), nodeRadius, unwalkableMask));
                grid[x, y] = new Node(walkable, worldPoint, x, y);

                

            }
        }
        
    }

    /// <summary>
    /// Get node from global world position
    /// </summary>
    /// <param name="worldPosition"></param>
    /// <returns></returns>
    public Node GetNodeFromWorldPosition(Vector3 worldPosition)
    {
        float x_pos_percent = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float y_pos_percent = (worldPosition.y + gridWorldSize.y / 2) / gridWorldSize.y;

        //avoid points outside of the grid
        x_pos_percent = Mathf.Clamp01(x_pos_percent);
        y_pos_percent = Mathf.Clamp01(y_pos_percent);

        //calculate grid coordinates
        int x = Mathf.RoundToInt((gridSizeX - 1) *x_pos_percent);
        int y = Mathf.RoundToInt((gridSizeY - 1) * y_pos_percent);

        return grid[x, y];

    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 1));
        //draw grid in scene view
        if (drawGrid)
        {
            if (grid!= null)
            {
                //Node playerNode = GetNodeFromWorldPosition(Player.position);
                foreach (Node n in grid)
                {
                    
                    Gizmos.color = (n.walkable) ? Color.white : Color.red;
                    // if (playerNode == n) { Gizmos.color = Color.blue; }               
                    Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - 0.1f));


                }
            }
        }
    }

    /// <summary>
    ///Get neighbours of single node 
    ///
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++){
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) { continue; }

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY <gridSizeY) //avoid out of grod nodes
                {
                    neighbours.Add(grid[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }

    
    

}
