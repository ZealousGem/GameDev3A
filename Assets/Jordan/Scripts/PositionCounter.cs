using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCounter : MonoBehaviour
{
    // Start is called before the first frame update

  
    LeaderBoardManager LeaderBoardManager;
   


    private void Start()
    {
        
        LeaderBoardManager = GameObject.FindWithTag("EditorOnly").GetComponent <LeaderBoardManager>();

    }
    private void OnTriggerEnter(Collider other)  // if the waypoint has been collided by a car the leaderboard manager will be called to update the leaderboard

    {
        if (other.GetComponent<RacingAI>())
        {
            
            LeaderBoardManager.UpdateList();

        }

        else if (other.GetComponent<Playercontroller>())
        {

            //LeaderBoardManager.UpdateList();
            //Player = other.GetComponent<Playercontroller>();
        }
    }
}
