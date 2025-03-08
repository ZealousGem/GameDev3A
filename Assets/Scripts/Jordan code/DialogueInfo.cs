using JetBrains.Annotations;
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
       // LoadData();
    }
    public IEnumerator LoadData()
    {
        string filepath = "Assets/Assets/StreamingAssets/JSONText.txt";
         // string filepath = Application.streamingAssetsPath + "/JSONText.txt";
     //   string filepath = Resources.Load<TextAsset>("");

        
        if (File.Exists(filepath))
        {
            string DialogueD = System.IO.File.ReadAllText(filepath);
            // uses a couritne to load data so it isn't null errored
            
            if (!string.IsNullOrEmpty(DialogueD))
            {
                DialogueData = JsonUtility.FromJson<DialogueData>(DialogueD); // converts the json data to the variables in dialogueData
                Debug.Log("successfully loaded");
            }

            else
            {
                Debug.Log("Dialogue data successfully loaded.");
            }

        }

        else
        {
            Debug.Log("File is missing");
        }

        yield return null;
        
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


