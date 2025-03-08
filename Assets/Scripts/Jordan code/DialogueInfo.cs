using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class DialogueInfo : MonoBehaviour
{
    // Start is called before the first frame update
    
   public DialogueData DialogueData= new DialogueData();
    public void Start()
    {
        LoadData();
    }
    public void LoadData()
    {
        string filepath = "D:\\GitShit\\GameDevRaceGame\\GameDev3A\\Assets\\Scripts\\Jordan code\\JSONText.txt";
        // string filepath = Application.persistentDataPath + "/JSONText.txt";
        if (File.Exists(filepath))
        {
            string DialogueD = System.IO.File.ReadAllText(filepath);

            DialogueData = JsonUtility.FromJson<DialogueData>(DialogueD);
            Debug.Log("successfully loaded");

        }

        else
        {
            Debug.Log("File is missing");
        }
        
    }

}



[System.Serializable]
public class DialogueData
{
    public List<People> Characters;
}


[System.Serializable]
public class People
{
    public string name;
    public List<DialogueLines> data;
}

[System.Serializable]
public class DialogueLines
{
    public string Text;
}

// https://www.youtube.com/watch?v=pVXEUtMy_Hc
// https://www.youtube.com/watch?v=XbdnG__wzZ8


