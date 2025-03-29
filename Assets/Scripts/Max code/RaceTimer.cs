using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceTimer : MonoBehaviour
{
    private float startTime = 40; //this is how much time is on the timer
    private float currentTime;
    public Text timerText;
    public bool raceActive = true;
    public UIManager UIManager;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        UpdateTimerUI();
        
    }

    // Update is called once per frame
    void Update()
    {
        // we only want to update the time when the race is active
        if (raceActive)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();
            //this connects to the method which update the UI element

            if (currentTime<=0)
            {
                // if the player runs out of time they have lost and the race ends
                raceActive = false;
                currentTime= 0;
                Debug.Log("Time's up! You lost.");
                UIManager.ShowGameFinishedMenu(false); // Shows lose text


            }

        }
        
    }
    void UpdateTimerUI()
    {
        //used to update the text on the timer
        timerText.text = "Time: " + Mathf.RoundToInt(currentTime) + "s";
    }
    public void AddTime(float timeBonus)
    {
        // this is used when the player reaches a checkpoint to give them extra time
        currentTime += timeBonus;
        UpdateTimerUI();
    }
}
