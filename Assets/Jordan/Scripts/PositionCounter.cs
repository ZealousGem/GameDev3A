using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCounter : MonoBehaviour
{
    // Start is called before the first frame update

    RacingAI Car;
    Playercontroller Player;
  public  LeaderBoardManager LeaderBoardManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RacingAI>())
        {
            Car = other.GetComponent<RacingAI>();
            Car.counter += 1;
            LeaderBoardManager.UpdateList();
        }

        else if (other.GetComponent<Playercontroller>())
        {
            Player = other.GetComponent<Playercontroller>();
        }
    }
}
