using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update

    public DialogueSystem start;
    public string[] name;
    public DialogueInfo info;
    public string Nextscene;
    void Start()
    {
        if (info != null)
        {
            StartCoroutine(LoadDialogue());// creates a couritnne so data can load before dialogue is implemented
        }
       else
        {
            Debug.Log("info not assigned");
        }
        

    }

    public IEnumerator LoadDialogue()
    {
      yield return StartCoroutine(info.LoadData());
        if (info.DialogueData.Characters != null || info.DialogueData.Characters.Count > 0) // will check if data is instatiated
        {
            StartCoroutine(Dialogue());
        }
        else
        {
            Debug.Log("data still not loaded");
        }

       
    }

    public IEnumerator Dialogue()
    {
        for (int i = 0; i < name.Length; i++) // this will be made so many different characters can speak to each other
        {
            //start = GetComponents<DialogueSystem>();
            start.StartDialogue(name[i]);
            Debug.Log(i);
            while (!start.end) // if the end bool is still false this will freeze the loop so the Queue can finish in DialogueSystem
            {
                yield return null;
            }
            start.end = true;
            // if true the next character will speak 
            //SceneManager.LoadScene(Nextscene);
            SkipDialogue();
        }
        
    }

    public void SkipDialogue()
    {
        LevelManager.instance.LoadScene(Nextscene);
    }

    // Update is called once per frame
   
}
