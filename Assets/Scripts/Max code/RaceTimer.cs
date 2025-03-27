using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceTimer : MonoBehaviour
{
    public float startTime = 60;
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
        if (raceActive)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();

            if (currentTime<=0)
            {
                raceActive = false;
                currentTime= 0;
                Debug.Log("Time's up! You lost.");
                UIManager.ShowGameFinishedMenu(false); // Shows lose text


            }

        }
        
    }
    void UpdateTimerUI()
    {
        timerText.text = "Time: " + Mathf.RoundToInt(currentTime) + "s";
    }
    public void AddTime(float timeBonus)
    {
        currentTime += timeBonus;
        UpdateTimerUI();
    }
}
