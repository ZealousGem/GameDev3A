using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
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
        // string filepath = "Assets/Assets/StreamingAssets/JSONText.txt"; // the location of the json file
        // string filepath = Application.streamingAssetsPath + "/JSONText.txt";
        //   string filepath = Resources.Load<TextAsset>("");
        string filepath = Path.Combine(Application.streamingAssetsPath, "JSONText.txt");

        if (System.IO.File.Exists(filepath))
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


// variables that will be used to catch the data in the JSON File
[System.Serializable]
public class DialogueData
{
    public List<People> Characters; // this is so we can add more than one character in the dialougue 
}


[System.Serializable]
public class People
{
    public string id;
   // public string name;
    public List<DialogueNames> character;
    public List<DialogueLines> data;
    public List<DialogueImages> images;// this is made so there can be many dialogue for the character to speak and it can contain many strings instead of one
}

[System.Serializable]
public class DialogueNames{
    public string name;
}

[System.Serializable]
public class DialogueLines
{
    public string Text;
}

[System.Serializable]
public class DialogueImages{
    public string picture;
}

// https://www.youtube.com/watch?v=pVXEUtMy_Hc
// https://www.youtube.com/watch?v=XbdnG__wzZ8
// https://www.youtube.com/watch?v=lFp8Z_3wa7M
// https://www.dafont.com/racing-engine-brake.font 
// https://www.dafont.com/racing-car.font?text=sci-fi 


