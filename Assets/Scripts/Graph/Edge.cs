using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Edge
{
    public Node startNode;
    public Node endNode;

    public Edge(Node startNode, Node endNode)
    {
        this.startNode = startNode;
        this.endNode = endNode;
    }

    public Edge(Edge copy, Dictionary<Node, Node> map)
    {
        startNode = map[copy.startNode];
        endNode = map[copy.endNode];
    }
}