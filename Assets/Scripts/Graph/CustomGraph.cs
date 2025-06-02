using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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


    public bool AStar(GameObject start, GameObject end, GameObject name)
    {
        Node TempStart = FindNode(start);
        Node TempEnd = FindNode(end);

        if (TempStart == null || TempEnd == null)
        {
          //  Debug.LogWarning("Start or End node is null.");
            return false;
        }

        // Reset all nodes
        foreach (Node n in points)
        {
            n.g = float.MaxValue;
            n.h = 0;
            n.f = 0;
            n.prevNode = null;
        }

        List<Node> open = new List<Node>();
        List<Node> close = new List<Node>();

        TempStart.g = 0;
        TempStart.h = distance(TempStart, TempEnd);
        TempStart.f = TempStart.h;

        open.Add(TempStart);

        while (open.Count > 0)
        {
            int i = SmallestF(open);
            Node curNode = open[i];

            // Debug current node
          //  Debug.Log("Evaluating node: " + curNode.findWaypoint().name + ", F = " + curNode.f);

            if (curNode.findWaypoint() == end)
            {
                // Create path
                MakePath(TempStart, TempEnd);
               // Debug.Log("Path found!");
                return true;
            }

            open.RemoveAt(i);
            close.Add(curNode);

            foreach (Edge e in curNode.edgeList)
            {
                Node neighbour = e.endNode;

                if (close.Contains(neighbour))
                    continue;

                Vector3 toNeighbor = neighbour.findWaypoint().transform.position - curNode.findWaypoint().transform.position;
                Vector3 toGoal = TempEnd.findWaypoint().transform.position - curNode.findWaypoint().transform.position;

                float penalty = 1f;
                float dot = (Vector3.Dot(toNeighbor.normalized, toGoal.normalized));
                if (dot < 0.2f)
                {
                  penalty = 3f;
                    
                }

                float tentativeG = curNode.g + distance(curNode, neighbour) * penalty;

                if (!open.Contains(neighbour))
                {
                    open.Add(neighbour);
                }

                // Only update if this path is better
                if (tentativeG < neighbour.g)
                {
                    neighbour.prevNode = curNode;
                    neighbour.g = tentativeG;
                    neighbour.h = distance(neighbour, TempEnd);
                    neighbour.f = neighbour.g + neighbour.h;

                    // Debug neighbor update
                   Debug.Log( name.name +" // Updating neighbor: " + neighbour.findWaypoint().name + "// New F = " + neighbour.f);
                }
            }
        }

        Debug.LogWarning("AStar failed to find a path from " + TempStart.findWaypoint().name + " to " + TempEnd.findWaypoint().name);
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

    public CustomGraph Copy()
    {
        CustomGraph copy = new CustomGraph();

        Dictionary<Node, Node> Map = new Dictionary<Node, Node>();

        foreach (Node node in points) // copys node from graph
        {
            Node newN = new Node(node);
            Map[node] = newN;
            copy.points.Add(newN);

        }

        foreach (Edge e in sides)
        {
            Node start = Map[e.startNode];
            Node end = Map[e.endNode];

            Edge newEdge = new Edge(start, end);
            copy.sides.Add(newEdge);
            start.edgeList.Add(newEdge);
        }

        foreach (Node n in pathing)
        {
            if (Map.TryGetValue(n, out Node mappedNode))
            {
                copy.points.Add(mappedNode);
            }
        }

        return copy;
    }
}