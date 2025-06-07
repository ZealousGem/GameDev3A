using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.TextCore.Text;
using System.IO;
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
    public bool isAutomatic;
    public TMP_Text description;
    public int counter = 0;
    public bool end;
    public float Speed;
    DialogueInfo info;

    private void Start()
    {
        Dialogue.SetActive(false);
        lines = new CustomQueue<string>(); // creates a Queue string for the dialogue 
        images = new CustomQueue<Sprite>(); // creates Queue sprite for images
        names = new CustomQueue<string>(); // creates Queue string for the names 
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
        
        Dialogue.SetActive(true);
        end = false;
        People characterD = info.DialogueData.Characters.Find(Characters => Characters.id == ChacterName); // this will create a character object and will instatite with the data from the josn file
        if (characterD != null)
        {
           
           
            Debug.Log("Successfully loaded characters.");
          
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

        string imagePath = Path.Combine(Application.streamingAssetsPath, file);
        
        if (File.Exists(imagePath)) // checks if image from the file path is found
        {
            byte[] filesInfo = File.ReadAllBytes(imagePath); // reads the bytes of image
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

    public void AutomaticClick()
    {
        DisplayNextSentence();
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
        Button.SetActive(false);
        StartCoroutine(TypeDialogue(sentence)); // displays the dialogue text in a courtieine to have text pop up in a timed sequence 
        login.Add(sentence);
        if (CharName == "Rival Ryan")
        {
            try { SoundManager.instance.PlaySound("ryan"); } catch { } 
            
        }

        else if (CharName == "Coach Walker")
        {
            try { SoundManager.instance.PlaySound("coach"); } catch { } 
        }
        counter += 1; // keeps track fo the front position element in the queue
       
    }

    public IEnumerator TypeDialogue(string sentence)
    {
        description.text = "";
        foreach (var T in sentence.ToCharArray()) // will loop the text string through it's characters
        {
            description.text += T; // will dsiplay each character at a certain timed update to create dialogue text animation 
            yield return new WaitForSeconds(0.03f);
        }

        if (isAutomatic) // bool will check if the dialogue is an automatic for the button not to be displayed
        {
            yield return new WaitForSeconds(2f);
            AutomaticClick();
        }

        else // will be displayed for player to progress to next element in queue if bool is false 
        {
            Button.SetActive(true);
        }
       
    }

    void EndDialogue() // will end the dialogue by setting bool to false allowing the for loop in dialogue manager to move the i to the next position
    {
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
