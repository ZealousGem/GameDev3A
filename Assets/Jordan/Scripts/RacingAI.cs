using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RacingAI : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    WayPointNode curNode;
    int index = 0;
    Vector3 WayPoint;
    public WayPointManager manager;
    float speed = 50f;
    void Start()
    {
         agent = GetComponent<NavMeshAgent>();

        if (manager.Waypoints.Count > 0)
        {
            curNode = manager.Waypoints[0];
            MoveCar();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
     
      NextNode();
    //  Debug.Log(index);

    }

    public void MoveCar()
    {
        if (curNode == null) return;
       
            WayPoint = curNode.pos;
            GameObject Waypoit = curNode.obj;
            transform.LookAt(WayPoint);
          
        //Debug.Log(curNode.obj);
             agent.destination = WayPoint;

      
        if (Waypoit.CompareTag("Checkpoint") && agent.speed != 10)
            {
                agent.speed -= 10f;


            }

            else
            {
                if (agent.speed != speed)
                {
                    agent.speed += 10f;
                   
                }

                else
                {

               
                        agent.speed = speed;
                     
                    
                   
                }
            }

        
       
    }

    public void NextNode()
    {
       // Debug.Log("NextNode() called");
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (curNode != null)
            {
                curNode = curNode.nextNode;

                if (curNode == manager.Waypoints[manager.Waypoints.Count - 1])
                {
                    curNode = manager.Waypoints[0];
                }
                MoveCar();
            }
          
        }

        
       
    }
}
