using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update

    public DialogueSystem start;
    public string[] name;
    public DialogueInfo info;
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
        for (int i = 0; i < name.Length; i++)
        {
            //start = GetComponents<DialogueSystem>();
            start.StartDialogue(name[i]);
            Debug.Log(i);
            while (!start.end)
            {
                yield return null;
            }
            start.end = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
