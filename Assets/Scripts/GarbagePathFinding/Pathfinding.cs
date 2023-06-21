using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    private Grid _grid;
    public Transform hunter;
    public Vector3 prey;

    public List<Node> path;
    
    // Start is called before the first frame update
    void Start()
    {
        _grid = GameObject.Find("Ocean").GetComponent<Grid>();
        // Calculate the path at the beginning
        Vector3 pPos = new Vector3(prey.x, _grid.transform.position.y, prey.z);
        Vector3 hPos = new Vector3(hunter.position.x, _grid.transform.position.y, hunter.position.z);
        FindPath(hPos, pPos);
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate and update the path
        //FindPath(hunter.position, prey.position);
    }

    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        // Get nodes from positions
        Node startNode = _grid.NodeFromWorldPoint(startPos);
        Node targetNode = _grid.NodeFromWorldPoint(targetPos);

        List<Node> openList = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        openList.Add(startNode);
        
        // Pathfinding
        while (openList.Count > 0)
        {
            // Get the current node
            Node currentNode = openList[0];
            for (int i = 1; i < openList.Count; i++)
            {
                if (openList[i].fCost < currentNode.fCost || openList[i].fCost == currentNode.fCost && openList[i].hCost < currentNode.hCost)
                    currentNode = openList[i];
            }   
            
            // Remove the current node from the open and add it to the closed
            openList.Remove(currentNode);
            closedSet.Add(currentNode);

            // Check if the path has been already found
            if (currentNode == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            // Check the neighbors of the current node
            List<Node> currentNeighbors = _grid.GetNeigbors(currentNode);
            foreach (Node n in currentNeighbors)
            {
                
                // Prevent cut-corner
                bool cutCorner = false;
                if (n.gridX != currentNode.gridX && n.gridY != currentNode.gridY)
                {
                    foreach (Node neighbor in _grid.GetNeigbors(n))
                    {
                        if (currentNeighbors.Contains(neighbor) && !neighbor.isWalkable)
                            cutCorner = true;
                    }
                }
                
                // If the node is blocked or already closed -> Skip
                if(!n.isWalkable || closedSet.Contains(n) || cutCorner)
                    continue;

                // Check if the new path is cheaper or node was just discovered
                int pathCost = currentNode.gCost + GetDistance(currentNode, n);
                if (pathCost < n.gCost || !openList.Contains(n))
                {
                    // Calculate the costs / the new costs
                    n.gCost = pathCost;
                    n.hCost = GetDistance(n, targetNode);
                    n.parent = currentNode;
                    // Add the node to openList if it issn't already contained
                    if(!openList.Contains(n)) 
                        openList.Add(n);
                } 
            }
        }
    }

    int GetDistance(Node a, Node b)
    {
        // Calculate the hCosts
        int distX = Mathf.Abs(a.gridX - b.gridX);
        int distY = Mathf.Abs(a.gridY - b.gridY);

        if (distX > distY)
            return 14 * distY + 10 * (distX - distY);
        
        return 14 * distX + 10 * (distY - distX);
    }

    void RetracePath(Node start, Node end)
    {
        // Save the found path into the grid
        List<Node> p = new List<Node>();
        Node currentNode = end;

        while (currentNode != start)
        {
            p.Add(currentNode);
            currentNode = currentNode.parent;
        }

        p.Reverse();
        path = p;
        _grid.paths.Add(path);
    }
    
}
