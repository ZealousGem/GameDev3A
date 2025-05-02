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
    public int LapCount;
    public UIManager endGameMenu;
    public GameObject inGameUI;
    public GameObject SpeedUI;
    // keeps track of laps in the race
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
            /*if (LapCount < 3)
            {
                LapCount += 1;
                PosUIManager.LapUI(LapCount);
                
            }*/
            GameObject obj = other.gameObject;
            ChangeLaps(obj);

        }
    }

    public void ChangeLaps(GameObject car)
    {
        if (car.GetComponent<RacingAI>())
        {
            // will add their own lap count once merged
            RacingAI carLap = car.GetComponent<RacingAI>();
            if (carLap.Laps < 3)
            {
                carLap.Laps += 1;
            }
           
        }

        else if (car.GetComponent<PlayerWaypointChecker>())
        {
            PlayerWaypointChecker playerWaypointChecker = car.GetComponent<PlayerWaypointChecker>();
            if (playerWaypointChecker.Laps > 3)
            {
                endGameMenu.ShowGameFinishedMenu(true);
                inGameUI.SetActive(false);
                SpeedUI.SetActive(false);
                PosUIManager.ShowLeaderBoardEnd();
            }

            else
            {
                PosUIManager.LapUI(playerWaypointChecker.Laps);
                playerWaypointChecker.Laps += 1;
            }
            
            
            // will add their own lap count once merged

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
