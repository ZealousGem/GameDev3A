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

    public Node(Node other)
    {
        this.waypoint = other.waypoint; // share same GameObject
        this.f = other.f;
        this.g = other.g;
        this.h = other.h;
        this.prevNode = null; // This will be re-linked
        this.edgeList = new List<Edge>();
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

