using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update

    
    public void Tutorial() // opens the check point dialogue scene
    {
        SoundManager.instance.StopSong();
        SoundManager.instance.PlaySong("Dialogue");
        LevelManager.instance.LoadCheckpointRD();
    }

    public void BeginnerLevel() // opens the beginner level scene
    {
        SoundManager.instance.StopSong();
        SoundManager.instance.PlaySong("Dialogue");
        LevelManager.instance.LoadBeginnerRD();
    }

    public void AdvancedLevel()  // opens the advanced level scene
    {
        SoundManager.instance.StopSong();
        SoundManager.instance.PlaySong("Dialogue");
        LevelManager.instance.LoadAdvancedRD();
    }

    public void QuitGame()  // quits game
    {
        LevelManager.instance.QuitGame();
    }

    public void MainMenu()  // opens main menu scene
    {
        LevelManager.instance.LoadMainMenu();
    }
}
