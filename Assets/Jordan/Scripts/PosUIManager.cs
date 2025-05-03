using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class PosUIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text text;
    public TMP_Text leaderboardT;
    public TMP_Text Laps;
    public LeaderBoardManager LeaderBoardManager;

    public TMP_Text leaderboardUI;

    public TMP_Text FinalLapUI;
    
    // Update is called once per frame
    void Update()
    {
       
    }

    private void Start() // displays the start postions of the cars from the leaderboard mamanger
    {

        // StartCoroutine(UICar());
         for (int i = 0; i < LeaderBoardManager.cars.Length; i++)
        {
            if (LeaderBoardManager.cars[i].GetComponent<PlayerWaypointChecker>())
            {
                int pos = LeaderBoardManager.position[i].position;
                text.text = pos.ToString();
            }
          }

        FinalLap(false);
        LapUI(0);
    }

   

  public void ChangePosUI(GameObject car) // this is will change the cars ui position above the car and will only change if their name is compared in the new list 
    {
       
        for (int i = 0; i < LeaderBoardManager.cars.Length; i++)
        {
          
            if (car == LeaderBoardManager.cars[i] && LeaderBoardManager.cars[i].GetComponent<PlayerWaypointChecker>())
            {
                PlayerWaypointChecker carUI = car.GetComponent<PlayerWaypointChecker>();
                for (int y = 0; y < LeaderBoardManager.position.Count; y++)
                {
                    if (carUI.name == LeaderBoardManager.position[y].name)
                    {
                        //  Debug.Log("here");
                        int pos = LeaderBoardManager.position[y].position;
                        text.text = pos.ToString();
                        return;
                    }
                }
            }
          
        }
    }



    public void LeaaderBoardUpdate(List<LeaderBoard> leaderboard) // updates the leaderboard ui by concatinating the string 
    {
        string texts = "";
        for (int i = 0; i < leaderboard.Count; i++)
        {
            texts += leaderboard[i].position + " - " + leaderboard[i].name + "\n";
        }

        leaderboardT.text = texts;
        
    }

    public void ShowLeaderBoardEnd()
    {
        leaderboardUI.text = leaderboardT.text;
    }

    public void LapUI(int laps)
    {
        Laps.text ="Laps: " +laps +"/3";
    }

    public void FinalLap(bool lol)
    {
        FinalLapUI.text = lol ? "Final Lap" : "";
    }

}



