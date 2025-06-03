using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCounter : MonoBehaviour
{
    // Start is called before the first frame update

  
    LeaderBoardManager LeaderBoardManager;
   


    private void Start()
    {
        
        LeaderBoardManager = GameObject.FindWithTag("Manager").GetComponent<LeaderBoardManager>();

    }
    private void OnTriggerEnter(Collider other)  // if the waypoint has been collided by a car the leaderboard manager will be called to update the leaderboard

    {
        if (other.GetComponent<RacingAI>()) // updates ai's current position in the leaderboard once ai has reached current waypoint
        {
           RacingAI Ai = other.GetComponent<RacingAI>();
            if (Ai.Laps <= 3)
            {
                
                LeaderBoardManager.UpdateList();
            }
           

        }

        else if (other.GetComponent<GraphRacingAI>()) // updates ai's current position in the leaderboard once ai has reached current waypoint
        {
            GraphRacingAI Ai = other.GetComponent<GraphRacingAI>();
            if (Ai.Laps <= 3)
            {
                Ai.NextNode();
                LeaderBoardManager.UpdateList();
              //  Debug.Log("gone through");
            }


        }

        else if (other.GetComponent<PlayerWaypointChecker>())
        {
            PlayerWaypointChecker player = other.GetComponent<PlayerWaypointChecker>(); // increases the players position and changes the player's current waypoint node to the new waypoint node
            if (player.Laps < 3)
            {
                player.nextNode();
                LeaderBoardManager.UpdateList(); // updates the player's position once they have reached the waypoint
            }
            
            
        }
    }
}
