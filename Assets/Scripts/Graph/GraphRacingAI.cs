using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GraphRacingAI : MonoBehaviour
{

    NavMeshAgent agent;

    NodeManager manager;

    public float Topspeed;
    public float BrakeSpeed;
    public float curSpeed;
    List<Node> path;
    int curIndex = 0;

    public string Carname;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        manager = FindObjectOfType<NodeManager>();
        MakePath();
        
    }

    void MakePath()
    {
        GameObject startLine = closetNodePoint();
        GameObject FinishLine = nextWayPoint(startLine);
        if (manager.graph.AStar(startLine, FinishLine))
        {
            path = manager.graph.getPath();
            agent.SetDestination(path[0].findWaypoint().transform.position);
        }
    }

    void moveCar()
    {
        if (path == null || path.Count == 0)
        {
            return;
        }

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            curIndex++;
            if (curIndex >= path.Count)
            {
                MakePath();
                curIndex = 0;
            }

            agent.SetDestination(path[curIndex].findWaypoint().transform.position);

            GameObject curNode = path[curIndex].findWaypoint();

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

    GameObject nextWayPoint(GameObject cur)
    {
        int element = System.Array.IndexOf(manager.waypoints, cur);
        if (element < 0) return manager.waypoints[0];
        int nextElement = (element +1) % manager.waypoints.Length;
        return manager.waypoints[nextElement];
    }

    GameObject closetNodePoint()
    {
        GameObject closest = null;
        float mindist = Mathf.Infinity;
        for (int i = 0; i < manager.waypoints.Length; i++)
        {
            float dist = Vector3.Distance(transform.position, manager.waypoints[i].transform.position);
            if (dist < mindist)
            {
                mindist = dist;
                closest = manager.waypoints[i];
            }
        }

        return closest;
    }

    GameObject farthestPoint()
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

    // Update is called once per frame
    void Update()
    {
        moveCar();
        agent.speed = Mathf.Lerp(agent.speed, curSpeed, Time.deltaTime * 2);
    }
}
