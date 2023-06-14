using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{

    public bool isWalkable;
    // World position
    public Vector3 position{ get; private set; }
    // Position within the grid
    public int gridX { get; private set; }
    public int gridY{ get; private set; }
    
    // Cost from source node
    public int gCost;
    
    // Cost to target node
    public int hCost;
    
    public Node parent;
    

    public Node(bool walk, Vector3 pos, int gX, int gY)
    {
        isWalkable = walk;
        position = pos;
        gridX = gX;
        gridY = gY;
    }

    public int fCost
    {
        get { return gCost + hCost; }
    }
}
