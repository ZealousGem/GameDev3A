using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomGraph
{
    // Start is called before the first frame update
    List<Edge> sides = new List<Edge>(); // contains all the edges between the nodes
    List<Node> points = new List<Node>(); // nodes that are contained in the track
    List<Node> pathing = new List<Node>(); // creates the best path to the specfied point in the track

    public CustomGraph() { }

    public void AddNode(GameObject id) // Adds all the waypoints into the node list 
    {
        Node tempNode = new Node(id);
        points.Add(tempNode);
    }

    public void AddEdges(GameObject prevNode, GameObject newNode) // adds all the edges between the two specfied nodes to create a avaialbe paths
    {
        Node cur = FindNode(prevNode); // finds specfied node in the points list to create an edge
        Node newN = FindNode(newNode);

        if (cur != null && newN != null) // checks if the two nodes are in the list to create the edges 
        {
            Edge edge = new Edge(cur, newN);
            sides.Add(edge);
            cur.edgeList.Add(edge); // adding in the edge for the node
        }
    }


    Node FindNode(GameObject f) // finds the instaited node in the point list 
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

    float distance(Node x, Node y) // caluclates the distance between the two nodes to determine if it's the best path
    {
        return (Vector3.SqrMagnitude(x.findWaypoint().transform.position - y.findWaypoint().transform.position));
    }

    int SmallestF(List<Node> s) // calculates the shortest distance in the node list 
    {
        float smallest = 0;
       // int coutner = 0;
        int itCount = 0;

        smallest = s[0].f; // instatie first value in the point list

        for (int i = 1; i < s.Count; i++) // finds the lowest iterator in the list
        {
            if (s[i].f <= smallest)
            {
                smallest = s[i].f;
                itCount = i;
            }
            // counter++
        }

        return itCount;
    }


    public bool AStar(GameObject start, GameObject end, GameObject name) // calculates the best path in the node edge list  from the start to the nend node
    {
        Node TempStart = FindNode(start); // node from start where the ai is
        Node TempEnd = FindNode(end); // end point where hte car wants to go 

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

        List<Node> open = new List<Node>(); // start point of path vertex which will end on a differetn vertex from the ned point, all the nodes that the ai could passoible head to
        List<Node> close = new List<Node>(); // end point path, which end point and start point ends on the same vertex, all the nodes that isnt aviable at this point

        TempStart.g = 0; // cost
        TempStart.h = distance(TempStart, TempEnd); // how far points are fomr eah other
        TempStart.f = TempStart.h; 

        open.Add(TempStart);

        while (open.Count > 0) // will loop though open list until path is determined, if not it returns no path
        {
            int i = SmallestF(open);
            Node curNode = open[i];

            

            if (curNode.findWaypoint() == end) // if the current node car is is at is already at the end point then a new path will be contructed
            {
                // Create path
                MakePath(TempStart, TempEnd);
               // Debug.Log("Path found!");
                return true;
            }

            open.RemoveAt(i); // removes node in the open list so it can find new nodes to determine where to next
            close.Add(curNode);

            foreach (Edge e in curNode.edgeList)
            {
                Node neighbour = e.endNode; // neighther that are near the current node the ai is located

                if (close.Contains(neighbour)) // if neighbours is near a node in the closed list then it will reset and find other nodes that are not closed 
                    continue;

                Vector3 toNeighbor = neighbour.findWaypoint().transform.position - curNode.findWaypoint().transform.position;
                Vector3 toGoal = TempEnd.findWaypoint().transform.position - curNode.findWaypoint().transform.position;

                float penalty = 1f;
                float dot = (Vector3.Dot(toNeighbor.normalized, toGoal.normalized)); // if the car goes backwards pnealty will be pllied to the t netative g which will make the cost more behnid the car
                if (dot < 0.2f)
                {
                  penalty = 3f;
                    
                }

                float tentativeG = curNode.g + distance(curNode, neighbour) * penalty; // this is a score that is given to determine the next node between the start and end node for the cart to move

                if (!open.Contains(neighbour)) // if neighbour is not in the close list it will be added to the open list for the ai to maybe use to head towards
                {
                    open.Add(neighbour);
                }

                // Only update if this path is better
                if (tentativeG < neighbour.g) // if the neighbours g is lower than the tnetative G , neighbour will get the tentative g value which will mean there as no need to use neightbours path
                {
                    neighbour.prevNode = curNode;
                    neighbour.g = tentativeG;
                    neighbour.h = distance(neighbour, TempEnd);
                    neighbour.f = neighbour.g + neighbour.h;

                    // Debug neighbor update
                  // Debug.Log( name.name +" // Updating neighbor: " + neighbour.findWaypoint().name + "// New F = " + neighbour.f);
                }
            }
        }

        Debug.LogWarning("AStar failed to find a path from " + TempStart.findWaypoint().name + " to " + TempEnd.findWaypoint().name);
        return false; // however if there is no path or way to the end node then it returns false
    }

    public List<Node> getPath()
    {
        return pathing;
    }

    public void MakePath(Node start, Node end) // instaites the path list node which is the path the ai will use to move through 
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

    public CustomGraph Copy() // makes a graph copy so many ai cars ccan you use it and not overidde each others open and closed lists 
    {
        CustomGraph copy = new CustomGraph();

        Dictionary<Node, Node> Map = new Dictionary<Node, Node>(); // makes a dictionary is easily contain the edges between the nodes 

        foreach (Node node in points) // copys node from graph
        {
            Node newN = new Node(node);
            Map[node] = newN;
            copy.points.Add(newN);

        }

        foreach (Edge e in sides) // copy all the edges each node contains 
        {
            Node start = Map[e.startNode];
            Node end = Map[e.endNode];

            Edge newEdge = new Edge(start, end);
            copy.sides.Add(newEdge);
            start.edgeList.Add(newEdge);
        }

        foreach (Node n in pathing) // copyies the waypoints added into the track
        {
            if (Map.TryGetValue(n, out Node mappedNode))
            {
                copy.points.Add(mappedNode);
            }
        }

        return copy; // returns the copied graph for the ai to use 
    }

    public void DrawEdges() // a debug that shows all the edges between the nodes and shows the possible paths the ai can go to 
    {
        foreach (Edge e in sides)
        {
         Vector3 start = e.startNode.findWaypoint().transform.position;
            Vector3 end = e.endNode.findWaypoint().transform.position;

            Debug.DrawLine(start, end, Color.green, 5f);

        }
    }
}