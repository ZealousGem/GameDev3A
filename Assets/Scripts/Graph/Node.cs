using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    // Start is called before the first frame update
    public List<Edge> edgeList = new List<Edge>();
    public Node path = null;
    GameObject waypoint;


    public float f, g, h;
    public Node prevNode;

    public Node(GameObject p)
    {
        waypoint = p;
        path = null;
    }

    public GameObject findWaypoint()
    {
        return waypoint;
    }

}

[System.Serializable]
public class Links { 

public enum dir { Uni, BI}
    public GameObject firstnode;
    public GameObject secondnode;
    public dir direction;

}

