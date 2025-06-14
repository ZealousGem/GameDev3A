using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public CanvasGroup pauseMenu; // Assign PauseMenuCanvas
    public CanvasGroup gameFinishedMenu; // Assign GameFinishedCanvas
    public RaceTimer raceTimer; // Reference to the race timer script

    private bool isPaused = false;
 
    public TextMeshProUGUI gameFinishedText;
    public string sound;


    // Start is called before the first frame update
    void Start()
    {
        HideCanvas(pauseMenu);
        HideCanvas(gameFinishedMenu);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
                TogglePause();
        }
    }
    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused )
        {
            try { SoundManager.instance.StopCarSound("engine"); } catch { }
            ShowCanvas(pauseMenu);
            Time.timeScale = 0;
        }
        else
        {
            HideCanvas(pauseMenu);
            Time.timeScale = 1;
        }
    }
    private void ShowCanvas(CanvasGroup canvas)
    {
        canvas.alpha = 1;
        canvas.interactable = true;
        canvas.blocksRaycasts = true;

    }
    private void HideCanvas(CanvasGroup canvas)
    {
        canvas.alpha = 0;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;

    }
    public void ShowGameFinishedMenu(bool won)
    {
        
        ShowCanvas(gameFinishedMenu);
        Time.timeScale = 0f;
        try { SoundManager.instance.StopCarSound("engine"); } catch { }
        gameFinishedText.text = won ? " Race Completed! You Win! " : " Time's Up! You Lose! ";
        //might want to simplify

    }

    public void FinishRace()
    {
        ShowCanvas(gameFinishedMenu);
        Time.timeScale = 0f;
        try { SoundManager.instance.StopCarSound("engine");
            SoundManager.instance.StopSong();
            SoundManager.instance.PlaySound("ui");
            SoundManager.instance.PlaySong("end");

        } catch { }
        
        gameFinishedText.text = " Race Completed! ";
    }

    public void ResumeGame()
    {
        TogglePause();
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        try { SoundManager.instance.StopSong(); SoundManager.instance.PlaySong(sound); } catch { }

    }
    public void QuitGame()
    {
        Application.Quit();

    }
    
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        try { SoundManager.instance.StopSong(); SoundManager.instance.PlaySong("Start"); } catch { }
        if (Time.timeScale == 1f)
        {
            Debug.Log("not forzen");
        }

        else
        {
            Debug.Log("forzen");
        }

    }
}
