using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface Lapcount // interface to track individual car lap count 
{
    public int Laps { get; set; }
}
public class LapCounter : MonoBehaviour
{
    // Start is called before the first frame update

   [HideInInspector]
    public int LapCount; // keeps track of laps in the race
    PosUIManager PosUIManager;
    void Start()
    {
        LapCount = 0;
        PosUIManager = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<PosUIManager>();
    }

    private void OnTriggerEnter(Collider other) // changes lap count once player has collided with last waypoint 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (LapCount < 3)
            {
                LapCount += 1;
                PosUIManager.LapUI(LapCount);
            }

           
        }
    }

    public void ChangeLaps(GameObject car)
    {
        if (car.GetComponent<RacingAI>())
        {
            // will add their own lap count once merged
        }

        else if (car.GetComponent<Playercontroller>())
        {
          // will add their own lap count once merged

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
