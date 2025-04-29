using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCounter : MonoBehaviour
{
    // Start is called before the first frame update

    RacingAI Car;
    Playercontroller Player;
    LeaderBoardManager LeaderBoardManager;
   


    private void Start()
    {
        
        LeaderBoardManager = GameObject.FindWithTag("EditorOnly").GetComponent <LeaderBoardManager>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RacingAI>())
        {
            
            LeaderBoardManager.UpdateList();
          
        }

        else if (other.GetComponent<Playercontroller>())
        {
            Player = other.GetComponent<Playercontroller>();
        }
    }
}
