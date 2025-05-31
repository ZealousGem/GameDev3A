using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomGraph
{
    // Start is called before the first frame update
    List<Edge> sides = new List<Edge>();
    List<Node> points = new List<Node>();
    List<Node> pathing = new List<Node>();

    public CustomGraph() { }

    public void AddNode(GameObject id)
    {
        Node tempNode = new Node(id);
        points.Add(tempNode);
    }

    public void AddEdges(GameObject prevNode, GameObject newNode)
    {
        Node cur = FindNode(prevNode);
        Node newN = FindNode(newNode);

        if (cur != null && newN != null)
        {
            Edge edge = new Edge(cur, newN);
            sides.Add(edge);
            cur.edgeList.Add(edge);
        }
    }


    Node FindNode(GameObject f)
    {
        foreach (Node i in points)
        {
            if (i.findWaypoint() == f)
            {
                return i;
            }
        }
        return null;
    }

    float distance(Node x, Node y)
    {
        return (Vector3.SqrMagnitude(x.findWaypoint().transform.position - y.findWaypoint().transform.position));
    }

    int SmallestF(List<Node> s)
    {
        float smallest = 0;
       // int coutner = 0;
        int itCount = 0;

        smallest = s[0].f;

        for (int i = 1; i < s.Count; i++)
        {
            if (s[i].f <= smallest)
            {
                smallest = s[i].f;
                itCount = i;
            }
        }

        return itCount;
    }


    public bool AStar(GameObject start, GameObject end)
    {
        Node TempStart = FindNode(start);
        Node TempEnd = FindNode(end);

        if (TempStart == null || TempEnd == null)
        {
            return false;
        }

        List<Node> open = new List<Node>();
        List<Node> close = new List<Node>();
        float tent_g = 0;
        bool tentImproved;

        TempStart.g = 0;
        TempStart.h = distance(TempStart, TempEnd);
        TempStart.f = TempStart.h;

        open.Add(TempStart);
        while (open.Count > 0)
        {
            int i = SmallestF(open);
            Node curNode = open[i];
            if (curNode.findWaypoint() == end)
            {
                // creates path from start to end
                MakePath(TempStart, TempEnd);
                return true;
            }

            open.RemoveAt(i);
            close.Add(curNode);
            Node neighbour;
            foreach (Edge e in curNode.edgeList)
            {
                neighbour = e.endNode;

                if (close.IndexOf(neighbour) > -1)
                    continue;

                tent_g = curNode.g + distance(curNode, neighbour);
                if (open.IndexOf(neighbour) == -1)
                {
                    open.Add(neighbour);
                    tentImproved = true;
                }

                else if (tent_g < neighbour.g)
                {
                    tentImproved = true;
                }

                else
                {
                    tentImproved = false;
                }


                if (tentImproved)
                {
                    neighbour.prevNode = curNode;
                    neighbour.g = tent_g;
                    neighbour.h = distance(curNode, TempEnd);
                    neighbour.f = neighbour.g + neighbour.h;
                }

            }
        }
        return false;
    }

    public List<Node> getPath()
    {
        return pathing;
    }

    public void MakePath(Node start, Node end)
    {
        pathing.Clear();
        pathing.Add(end);
        var p = end.prevNode;
        while (p != start && p != null)
        {
            pathing.Insert(0, p);
            p = p.prevNode;
        }
        pathing.Insert(0, start);
    }
}