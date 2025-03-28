using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Tutorial()
    {
        LevelManager.instance.LoadCheckpointRD();
    }

    public void BeginnerLevel()
    {
        LevelManager.instance.LoadBeginnerRD();
    }

    public void AdvancedLevel()
    {
        LevelManager.instance.LoadAdvancedRD();
    }

    public void QuitGame()
    {
        LevelManager.instance.QuitGame();
    }
}
