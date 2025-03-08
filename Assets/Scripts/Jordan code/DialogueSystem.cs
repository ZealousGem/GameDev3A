using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private Queue<string> lines;
    public List<string> login;
    public Text Charname;
    public string nameDisplay;
    string colon = ":";
    public Text description;
    public int counter = 0;
    public bool end;
    public DialogueInfo info;
    private void Start()
    {
        lines = new Queue<string>();
        end = true;

        if (info == null)
        {
            info = FindAnyObjectByType<DialogueInfo>();
            

        }

        if (info == null)
        {
            Debug.LogError("DialogueInfo component is not assigned or not found in the scene.");
        }
    }

    public void StartDialogue(string ChacterName)
    {
        // character.SetActive(true); 
        //Debug.Log("working");
        end = false;
        People characterD = info.DialogueData.Characters.Find(Characters => Characters.name == ChacterName);
        if (characterD != null)
        {
           
           
            Debug.Log("Successfully loaded characters.");
            Charname.text = characterD.name;
            nameDisplay = characterD.name + colon;
            lines.Clear();

            foreach (DialogueLines sent in characterD.data)
            {
                lines.Enqueue(sent.Text);
            }

            DisplayNextSentence();
        }

        else
        {
            Debug.Log("character not found");
        }
        
        
           
        
        
    }

    public void DisplayNextSentence()
    {
        //Debug.Log("next dialogue");
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = lines.Dequeue();
        // Debug.Log(sentence);
        description.text = sentence;
        login.Add(sentence);
        counter += 1;

    }

    void EndDialogue()
    {
        // character.SetActive(false);
        Charname.text = "";
        description.text = "";
        end = true;
        counter = 0;
    }

   

}
