using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public LayerMask unwalkableMask;
    public Vector2 gridSize;
    public float cellSize;
    private Node[,] _grid;
    
    
    private int nodeCountX, nodeCountY;
    public List<List<Node>> paths = new List<List<Node>>();

    // For debugging reasons and to better visualize the grid
    private void OnDrawGizmos()
    {
        /*Gizmos.DrawWireCube(transform.position, new Vector3(gridSize.x, 1, gridSize.y));
        
        // Visualize the grid, red if NOT walkable, white if walkable and blue is the best path to the target
        if (_grid != null)
        {
            foreach (Node n  in _grid)
            {
                Gizmos.color = n.isWalkable ? Color.white : Color.red;
                foreach (List<Node> path in paths)
                {
                    if (path.Contains(n))
                        Gizmos.color = Color.blue;
                }
                Vector3 gizPos = n.position;
                Gizmos.DrawCube(gizPos, Vector3.one * (cellSize-.1f));
            }
        }*/
    }

    // Start is called before the first frame update
    void Awake()
    {
        // Calculate how much nodes there are
        nodeCountX = Mathf.RoundToInt(gridSize.x / cellSize);
        nodeCountY = Mathf.RoundToInt(gridSize.y / cellSize);
        CreateGrid();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateGrid()
    {
        // Initialize the grid and calculate the bottom left position of the grid
        _grid = new Node[nodeCountX, nodeCountY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridSize.x / 2 - Vector3.forward * gridSize.y / 2;
        // Create the nodes, check if they are walkable and calculate their position starting from the bottom left
        for (int x = 0; x < nodeCountX; x++)
        {
            for (int y = 0; y < nodeCountY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * cellSize + cellSize / 2) + Vector3.forward * (y * cellSize + cellSize / 2);
                bool walkable = !(Physics.CheckSphere(worldPoint, cellSize/2, unwalkableMask));
                _grid[x, y] = new Node(walkable, worldPoint, x, y);
            }
        }
    }

    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        // Minus the cordinates of the origin
        // Origin of the scene 0,0,0
        // Origin of the ocean 9.4678,0,-51,8906
        int x = Mathf.RoundToInt(worldPosition.x - transform.position.x + gridSize.x / 2);
        int y = Mathf.RoundToInt(worldPosition.z - transform.position.z + gridSize.y / 2);
        return _grid[x, y];
    }

    public List<Node> GetNeigbors(Node n)
    {
        List<Node> neighbors = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                // Skip the current node
                if(x==0 && y==0)
                    continue;

                // Check if the node is actually existing and within the grid
                int checkX = n.gridX + x;
                int checkY = n.gridY + y;
                if (checkX >= 0 && checkX < gridSize.x && checkY >= 0 && checkY < gridSize.x)
                {
                    neighbors.Add(_grid[checkX, checkY]);
                }
            }
        }

        return neighbors;
    }
}
