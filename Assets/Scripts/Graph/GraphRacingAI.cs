using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GraphRacingAI : MonoBehaviour, PosCounter, Lapcount
{

    NavMeshAgent agent;

    NodeManager manager;
    WayPointManager wayPointManager;
    WayPointNode curNode;
    public float Topspeed;
    public float BrakeSpeed;
    public float curSpeed;
    public List<Node> path;
    int curIndex = 0;
    Vector3 WayPoint;
    CustomGraph custom;
    public string Carname;
    public float WaypointBorder;


    [HideInInspector]
    public int counter { get; set; }
    public float DistancefromWaypoint { get; set; }
    public int Laps { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Carname = gameObject.name; // sets the cars name based on the name given through the factory adt
        name = Carname;
        counter = 0; // sets interface variables to 0 
        DistancefromWaypoint = 0f;
        Laps = 0;
        agent = GetComponent<NavMeshAgent>();
        manager = FindObjectOfType<NodeManager>();
        custom = manager.graph.Copy(); // uses a copy of the graph to use it safely so it doesn't overide the node
       // MakePath();

        wayPointManager = FindObjectOfType<WayPointManager>();
        if (wayPointManager.Waypoints.Count() > 0) // will actvate the first node in the linkedlist
        {
            curNode = wayPointManager.Waypoints.NodeAcess(0); // sets waypointnode to the head node in the linkedlist 
             // actviates movement for ai to head to waypointnodes position 
        }
          MakePath(); // determines the path from the start node in the point list
        SetWaypoint(); // sets the waypoint for the leaderboard linked list 
        

    }

    void MakePath() // sets the path for the ai to use 
    {

        GameObject startLine = closetNodePoint();
        GameObject FinishLine = nextWayPoint(startLine);

      
        if (custom.AStar(startLine, FinishLine, this.gameObject)) // uses astar heaustric function from graph adt to determine the best path between the two nodes 
        {
            path = custom.getPath();
            agent.SetDestination(path[0].findWaypoint().transform.position);
        }
        else
        {
            Debug.LogWarning("Pathfinding failed.");
        }
    }

    public void DistFromCheckPoint() // calculates ai distance from the current waypoint
    {
        DistancefromWaypoint = Vector3.Distance(transform.position, WayPoint);
    }

    void moveCar() // moves the car through the points if a path has been found 
    {
        GameObject curNode;
        if (path == null || path.Count == 0) // will return if no path is found 
        {
            return;
        }

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance) // will kepp moving until nav agent has reached inteneded destination 
        {
             curIndex++;
            if (curIndex >= path.Count) // will use an index to determine what node it is on in the path list
            {
                GameObject startLine = path[path.Count - 1].findWaypoint();
                GameObject FinishLine = nextWayPoint(startLine);
              
                if (custom.AStar(startLine, FinishLine, this.gameObject)) // will use the astar fucntion to determine the best path to the endpoint 
                {
                    path= custom.getPath(); // retirves the calculated path
                    curIndex = 0;
                    if (path != null && path.Count > 0) 
                    {
                       // Debug.Log(gameObject.name +" Start Point" + path[0].findWaypoint());
                        agent.SetDestination(path[0].findWaypoint().transform.position);
                        curNode = path[curIndex].findWaypoint(); // sets current node in the elemnt in the path list 
                        if (curNode.CompareTag("Checkpoint"))
                        {
                            curSpeed = BrakeSpeed;
                        }

                        else
                        {
                            curSpeed = Topspeed;
                        }
                    }
                }
              
            }

            else // if the ai has reached the final element in the path list, it will reset the index to 0 making a loop 
            {
               // Debug.Log(gameObject.name +" End Point" + path[curIndex].findWaypoint());
                agent.SetDestination(path[curIndex].findWaypoint().transform.position);
                curNode = path[curIndex].findWaypoint();
                if (curNode.CompareTag("Checkpoint"))
                {
                    curSpeed = BrakeSpeed;
                }

                else
                {
                    curSpeed = Topspeed;
                }

            }

            

            

           
            
        }
    }

    GameObject nextWayPoint(GameObject cur) // determines the end waypoint
    {
        int element = System.Array.IndexOf(manager.waypoints, cur);
        if (element < 0) { //Debug.Log(gameObject.name+ " " + manager.waypoints[0]); 
            return manager.waypoints[0];  }
                
        int nextElement = (element +1) % manager.waypoints.Length;
       // Debug.Log(gameObject.name+ " " +manager.waypoints[nextElement]);
        return manager.waypoints[nextElement];

    }

    GameObject closetNodePoint() // this determines which node the ai is located so it can be used to calcualte the path from the start node 
    {
        GameObject closest = null;
        float mindist = Mathf.Infinity;
        for (int i = 0; i < manager.waypoints.Length; i++)
        {
            float dist = Vector3.Distance(transform.position, manager.waypoints[i].transform.position);
            if (dist < mindist) // checks if the distance has an end or a limit 
            {
                mindist = dist;
                closest = manager.waypoints[i];
            }
        }
      //  Debug.Log(gameObject.name + " "+closest);
        return closest;
    }

    GameObject farthestPoint() // useless method 
    {
        GameObject farwaway = null;
        float mindist = -Mathf.Infinity;
        for (int i = 0; i < manager.waypoints.Length; i++)
        {
            float dist = Vector3.Distance(transform.position, manager.waypoints[i].transform.position);
            if (dist > mindist)
            {
                mindist = dist;
                farwaway = manager.waypoints[i];
            }
        }

        return farwaway;
    }

    public void NextNode() // this is used to count hhow many points the ai has past thourgh to determine it's position in the leaderboard 
    {

        if (DistancefromWaypoint < WaypointBorder)
        {
            if (curNode != null)
            {
                counter++; // updates  the counter to determine what position the car is in
                curNode = curNode.nextNode;
               // Debug.Log(gameObject.name + " " + counter);
                // moves to nextNode

                if (curNode == wayPointManager.Waypoints.head) // checks if the linkedlist loop has reset 
                {
                    curNode = wayPointManager.Waypoints.head;
                }
                if (curNode == null) return;

                SetWaypoint(); // the next nodes location

                // MoveCar(); // utlises movecar method once curnode has been set

            }
        }
           

        



    }

    void SetWaypoint() // sets to new waypoint wants ai has reached the previous one 
    {
        if (curNode == null) return;
        WayPoint = curNode.pos;
    }

    // Update is called once per frame
    void Update()
    {
        moveCar();
        agent.speed = Mathf.Lerp(agent.speed, curSpeed, Time.deltaTime * 2);
        DistFromCheckPoint();
        NextNode();
       
       
    }
}
