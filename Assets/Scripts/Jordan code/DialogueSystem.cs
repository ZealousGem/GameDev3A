using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.TextCore.Text;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private CustomQueue<string> lines;
    private CustomQueue<Sprite> images;
    private CustomQueue<string> names;
    public GameObject Dialogue;
    public GameObject Button;
    public Image image;
    public List<string> login;
    public TMP_Text Charname;
    string nameDisplay;
    string colon = ":";
    public TMP_Text description;
    public int counter = 0;
    public bool end;
    public float Speed;
    DialogueInfo info;
    private void Start()
    {
        lines = new CustomQueue<string>(); // creates a Queue string for the dialogue 
        images = new CustomQueue<Sprite>(); // creates Queue sprite for images
        names = new CustomQueue<string>();
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
        Dialogue.SetActive(true);
        end = false;
        People characterD = info.DialogueData.Characters.Find(Characters => Characters.id == ChacterName); // this will create a character object and will instatite with the data from the josn file
        if (characterD != null)
        {
           
           
            Debug.Log("Successfully loaded characters.");
           // Charname.text = characterD.name;
          //  nameDisplay = characterD.name + colon;
            lines.Clear();
            images.Clear();
            names.Clear();
            
           // clears any elements that are in the queue

            foreach (DialogueLines sent in characterD.data)
            {
                lines.Enqueue(sent.Text); // will add all the text elements from object into the queue to create a sequential order
            }

            foreach (DialogueImages sent in characterD.images)
            {
                Sprite curImage = LoadSprite(sent.picture); // finds the file path of image
                images.Enqueue(curImage); // will add all sprites from object into the queue to create a sequential order
               
                    
            }

            foreach (DialogueNames sent in characterD.character)
            {
                names.Enqueue(sent.name);
            }

            DisplayNextSentence(); // this will activate to start the elemtns to be removed from the queue
        }

        else
        {
            Debug.Log("character not found");
        }
        
        
           
        
        
    }

    public Sprite LoadSprite(string file) // reads the path to find the image to display
    {
        
        if (System.IO.File.Exists(file)) // checks if image from the file path is found
        {
            byte[] filesInfo = System.IO.File.ReadAllBytes(file); // reads the bytes of image
            Texture2D texture = new Texture2D(2,2); // sets texture size
            texture.LoadImage(filesInfo); // loads the image using the bytes from read file 
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f)); // returns the newly created read sprite image to make the sprite be loaded into the queue
        }

        else
        {
            Debug.Log("no image");
            return null; // will return null if file couldn't be read
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
        Sprite Nextimage = images.Dequeue();
        string CharName = names.Dequeue();
        Charname.text = CharName;
        image.sprite = Nextimage;
        // Debug.Log(sentence);
        //description.text = sentence;
        Button.SetActive(false);
        StartCoroutine(TypeDialogue(sentence));
        login.Add(sentence);
        counter += 1;

    }

    public IEnumerator TypeDialogue(string sentence)
    {
        description.text = "";
        foreach (var T in sentence.ToCharArray())
        {
            description.text += T;
            yield return new WaitForSeconds(0.03f);
        }
        Button.SetActive(true);
    }

    void EndDialogue() // will end the dialogue by setting bool to false allowing the for loop in dialogue manager to move the i to the next position
    {
        // character.SetActive(false);
        Charname.text = "";
        description.text = "";
        end = true;
        counter = 0;
        login.Clear();
        images.Clear();
        names.Clear();
        Dialogue.SetActive(false);
    }

    


}
