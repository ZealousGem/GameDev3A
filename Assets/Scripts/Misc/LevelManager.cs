using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    // Start is called before the first frame update

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
    
    public void LoadCheckpointRD()
    {
        SceneManager.LoadScene("Checkpoint Race Dialogue");

    }
    public void LoadBeginnerRD()
    {
        SceneManager.LoadScene("Beginner Race Dialogue");

    }
    public void LoadAdvancedRD()
    {
        SceneManager.LoadScene("Advanced Race Dialogue");

    }
    public void QuitGame()
    {
        Application.Quit();
    }

    
}
