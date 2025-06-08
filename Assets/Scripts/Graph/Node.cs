using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node // this will store the waypoints which will be the direction the car will go
{
    // Start is called before the first frame update
    public List<Edge> edgeList = new List<Edge>(); // edges node which wich connects with other nodes
    public Node path = null; // current path car will follow
    GameObject waypoint; // Game Object point located on the track


    public float f, g, h; // used to calculate path in the A* star function, h will be how much it will be to the goal, g will be how much it will be at the start, and f will determine if the path is vialbe
    public Node prevNode; // this was the previous node the car came from 

    public Node(GameObject p) // contrcutor to instantie the waypoint into the node object
    {
        waypoint = p;
        path = null;
    }

    public Node(Node other) // an overidden constructor to be used to copy the nodes so other ai can use it and not overide each other 
    {
        this.waypoint = other.waypoint; // share same GameObject
        this.f = other.f;
        this.g = other.g;
        this.h = other.h;
        this.prevNode = null; // This will be re-linked
        this.edgeList = new List<Edge>();
    }

    public GameObject findWaypoint() // retrives the waypoint object to compare other waypoints
    {
        return waypoint;
    }

}

[System.Serializable]
public class Links {  // will be used to link the nodes together which can be either univatlateral or bialteral 

public enum dir { Uni, BI}
    public GameObject firstnode;
    public GameObject secondnode;
    public dir direction;

}

