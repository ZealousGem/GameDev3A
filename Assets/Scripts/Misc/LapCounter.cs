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
        PosUIManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<PosUIManager>();
    }

    private void OnTriggerEnter(Collider other) // changes lap count once player or ai has collided with last waypoint 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject obj = other.gameObject;
            ChangeLaps(obj);

        }

        else if (other.gameObject.CompareTag("Cars"))
        {
            GameObject obj = other.gameObject;
            ChangeLaps(obj);
        }
    }

    public void ChangeLaps(GameObject car) // increments lap count or player and ai
    {
        if (car.GetComponent<RacingAI>())
        {
            // will add their own lap count once merged
            RacingAI carLap = car.GetComponent<RacingAI>();
            if (carLap.Laps < 3) // won't increment if the lapcount is more than 3 laps 
            {
                carLap.Laps += 1;
            }
           
        }

        else if (car.GetComponent<PlayerWaypointChecker>())
        {
            PlayerWaypointChecker playerWaypointChecker = car.GetComponent<PlayerWaypointChecker>();
            if (playerWaypointChecker.Laps > 3) // won't increment if the lapcount is more than 3 laps 
            {
                endGameMenu.FinishRace(); // once player has completed 3 laps the game end screen and the leaderboard would appear 
                inGameUI.SetActive(false);
                SpeedUI.SetActive(false);
                PosUIManager.ShowLeaderBoardEnd();
               
            }

            else
            {
                PosUIManager.LapUI(playerWaypointChecker.Laps); // if lap count is less than 3 laps, the players laps variable will increment 
                playerWaypointChecker.Laps += 1;
                if (playerWaypointChecker.Laps > 3) // if the player is on the final lap a couritine will that will display the final lap UI
                {
                    StartCoroutine(ShowFinalLap());
                }
            }
            
            
           

        }
    }

    public IEnumerator ShowFinalLap() // displays LapUI, using a couritine 
    {
        PosUIManager.FinalLap(true);
        yield return new WaitForSeconds(2f);
        PosUIManager.FinalLap(false);
    }

}
