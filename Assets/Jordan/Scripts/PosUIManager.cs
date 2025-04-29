using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PosUIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text[] text;
    public TMP_Text leaderboardT;
    public LeaderBoardManager LeaderBoardManager;
    // Update is called once per frame
    void Update()
    {
       
    }

    private void Start()
    {
        for (int i = 0; i < LeaderBoardManager.cars.Length; i++)
        {
            int pos = LeaderBoardManager.position[i].position;
            text[i].text = pos.ToString();
        }
    }

  public void ChangePosUI(GameObject car)
    {
       
        for (int i = 0; i < LeaderBoardManager.cars.Length; i++)
        {
           
            if (car == LeaderBoardManager.cars[i] &&LeaderBoardManager.cars[i].GetComponent<RacingAI>())
            {
              
                RacingAI carUI = car.GetComponent<RacingAI>();
                for (int y = 0; y < LeaderBoardManager.position.Count; y++)
                {
                    if (carUI.name == LeaderBoardManager.position[y].name)
                    {
                        Debug.Log("here");
                        int pos = LeaderBoardManager.position[y].position;
                        text[i].text = pos.ToString();
                        return;
                    }
                }
                
            }
          
        }
    }



    public void LeaaderBoardUpdate(List<LeaderBoard> leaderboard)
    {
        string texts = "";
        for (int i = 0; i < leaderboard.Count; i++)
        {
            texts += leaderboard[i].position + " - " + leaderboard[i].name + "\n";
        }

        leaderboardT.text = texts;
    }
}



