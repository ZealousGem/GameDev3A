using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Edge
{
    public Node startNode; // start point and end point that will be used to travl between the two nodes
    public Node endNode;

    public Edge(Node startNode, Node endNode) // contrsutor instatine the start node and end node 
    {
        this.startNode = startNode;
        this.endNode = endNode;
    }

    public Edge(Edge copy, Dictionary<Node, Node> map) // copy to allow other cars to use customegraph 
    {
        startNode = map[copy.startNode];
        endNode = map[copy.endNode];
    }
}