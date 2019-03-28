using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathFinding : MonoBehaviour
{
   // public Transform seeker, target;
    Grid grid;
    RequestPathManager requestManager;

    void Awake()
    {
        grid = GetComponent<Grid>();
        requestManager = GetComponent<RequestPathManager>();
    }

 public void StartFindPath(Vector3 startPos, Vector3 targetPos)
    {
        StartCoroutine(FindPath(startPos, targetPos));
    }


   IEnumerator FindPath(Vector3 startPos, Vector3 targetPos)
    {

        Vector3[] waypoints = new Vector3[0];
        bool pathSucces = false;

        //Init node positions
        Node startNode = grid.GetNodeFromWorldPosition(startPos);
        Node targetNode = grid.GetNodeFromWorldPosition(targetPos);

        if (startNode.walkable && targetNode.walkable)
        {
            //Unconsidered nodes
            List<Node> openNodeSet = new List<Node>();
            //Considered nodes
            HashSet<Node> closedNodeSet = new HashSet<Node>();
            openNodeSet.Add(startNode);

            while (openNodeSet.Count > 0)
            {
                Node currentNode = openNodeSet[0];
                for (int i = 1; i < openNodeSet.Count; i++)
                {
                    if (openNodeSet[i].fCost < currentNode.fCost || openNodeSet[i].fCost == currentNode.fCost)
                    {
                        if (openNodeSet[i].hCost < currentNode.hCost)
                        {
                            currentNode = openNodeSet[i];

                        }
                    }

                }
                openNodeSet.Remove(currentNode);
                closedNodeSet.Add(currentNode);

                if (currentNode == targetNode)
                {
                    //Found path
                    pathSucces = true;
                    break;
                }
                //For each neighbour of the current node
                foreach (Node neighbour in grid.GetNeighbours(currentNode))
                {
                    if (!neighbour.walkable || closedNodeSet.Contains(neighbour))
                    {
                        continue; //skip
                    }

                    //calculate new path to neighbour
                    int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                    //if new path to neighbour is shorter or neighbour is not in open
                    if (newMovementCostToNeighbour < neighbour.gCost || !openNodeSet.Contains(neighbour))
                    {
                        //calculate costs to neighbour
                        neighbour.gCost = newMovementCostToNeighbour;
                        neighbour.hCost = GetDistance(neighbour, targetNode);
                        neighbour.parent = currentNode;

                        if (!openNodeSet.Contains(neighbour))
                        {
                            openNodeSet.Add(neighbour);
                        }
                    }
                }


            }
        }
        //wait for one frame before return
        yield return null;
        if (pathSucces)
        {
            waypoints = RetracePath(startNode, targetNode);
        }
        requestManager.FinishedProcessingPath(waypoints, pathSucces);
    }

    /// <summary>
    /// Retrace path back from end node to startnode
    /// </summary>
    /// <param name="startNode"></param>
    /// <param name="endNode"></param>
    /// <returns></returns>
    Vector3 [] RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode!= startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        Vector3[] waypoints =SimplyfyPath(path);
        Array.Reverse(waypoints);
        return waypoints;
    }

    /// <summary>
    /// Simplyfy path only to trace points only on turns
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    Vector3 [] SimplyfyPath(List<Node> path) {
        List<Vector3> waypoints = new List<Vector3>();
        Vector2 directionOld = Vector2.zero;
        //waypoints.Add(path[0].worldPosition);

        for (int i = 1; i < path.Count; i++)
        {
            Vector2 directionNew = new Vector2(path[i - 1].gridX - path[i].gridX, path[i - 1].gridY - path[i].gridY);
            if (directionNew != directionOld)
            {
                waypoints.Add(path[i].worldPosition);
            }
            directionOld = directionNew;
        }
        return waypoints.ToArray();
}


    /// <summary>
    /// Return how many moves must be done to get to nodes. Also calculate travel cost
    /// </summary>
    /// <param name="firstNode"></param>
    /// <param name="secondNode"></param>
    /// <returns></returns>
    int GetDistance(Node firstNode, Node secondNode)
    {
        int distanceX = Mathf.Abs(firstNode.gridX - secondNode.gridX);
        int distanceY = Mathf.Abs(firstNode.gridY - secondNode.gridY);

        if(distanceX > distanceY)
        {
            return 14 * distanceY + 10 * (distanceX - distanceY);
        }
        else
        {
            return 14 * distanceX + 10 * (distanceY - distanceX);

        }
    }



}
