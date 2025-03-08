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
        lines = new Queue<string>(); // creates a Queue string for the dialogue 
        end = true;

        if (info == null)
        {
            info = FindAnyObjectByType<DialogueInfo>(); // instiates the inforamtion from the Json file
            

        }

        if (info == null)
        {
            Debug.LogError("DialogueInfo component is not assigned or not found in the scene.");
        }
    }

    public void StartDialogue(string ChacterName) // method that will start the dialogue using the characters name in the string array from diaslogue manager
    {
        // character.SetActive(true); 
        //Debug.Log("working");
        end = false;
        People characterD = info.DialogueData.Characters.Find(Characters => Characters.name == ChacterName); // this will create a character object and will instatite with the data from the josn file
        if (characterD != null)
        {
           
           
            Debug.Log("Successfully loaded characters.");
            Charname.text = characterD.name;
            nameDisplay = characterD.name + colon;
            lines.Clear(); // clears any elements that are in the queue

            foreach (DialogueLines sent in characterD.data)
            {
                lines.Enqueue(sent.Text); // will add all the text elements from object into the queue to create a sequential order
            }

            DisplayNextSentence(); // this will activate to start the elemtns to be removed from the queue
        }

        else
        {
            Debug.Log("character not found");
        }
        
        
           
        
        
    }

    public void DisplayNextSentence() // this method is activated by the next button input
    {
        //Debug.Log("next dialogue");
        if (lines.Count == 0) // if all the elements have been dequed the dailogue will end
        {
            EndDialogue();
            return; // returns method
        }
        string sentence = lines.Dequeue(); // everytime the diplsay is pressed the element in front will be removed and makes the element behind in fron of the Queue
        // Debug.Log(sentence);
        description.text = sentence; 
        login.Add(sentence);
        counter += 1;

    }

    void EndDialogue() // will end the dialogue by setting bool to false allowing the for loop in dialogue manager to move the i to the next position
    {
        // character.SetActive(false);
        Charname.text = "";
        description.text = "";
        end = true;
        counter = 0;
    }

   

}
