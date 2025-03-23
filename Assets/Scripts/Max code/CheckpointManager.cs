using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    public RaceTimer raceTimer;
    public float timeBonus = 5f;

    public List<Transform> CheckpointTransforms; // List to hold all checkpoints in the race
    private CustomStack<Transform> checkpointStack;  // Custom stack to manage checkpoint order
    private Transform currentCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        checkpointStack = new CustomStack<Transform>();

        // Push checkpoints onto the stack in reverse order
        // (so the first checkpoint is on top)
        for (int i =CheckpointTransforms.Count - 1;i >=0; i--)
        {
            checkpointStack.Push(CheckpointTransforms[i]);
        }
        SetNextCheckpoint();

    }
    // Sets the next checkpoint as the target
    void SetNextCheckpoint()
    {
        if (!checkpointStack.IsEmpty())
        {
            currentCheckpoint = checkpointStack.Peek(); // Get the next checkpoint
            HighlightCheckpoint(currentCheckpoint, Color.green); // Highlight it in green
        }
        else
        {
            Debug.Log(" Race Completed!");
            raceTimer.raceActive = false;
            // Stop the race timer when all checkpoints are cleared

        }

    }

    // Returns the next checkpoint the player needs to reach
    //need to check as their are no referencces
    public Transform GetNextCheckpoint()
    {
        return currentCheckpoint;
        
    }

    // Called when a player reaches a checkpoint
    public void CheckpointReached(Transform checkpoint)
    {
        // Check if the player reached the correct (top of stack) checkpoint
        if (checkpoint ==checkpointStack.Peek())
        {
            checkpointStack.Pop();
            // Remove the checkpoint from the stack
            Debug.Log("checkpoint reached:" + checkpoint.name);


            raceTimer.AddTime(timeBonus);

            HighlightCheckpoint(checkpoint, Color.gray);
            // Change checkpoint color to gray

            Destroy(checkpoint.gameObject);

            SetNextCheckpoint();

        }
        if (checkpointStack.IsEmpty())
        {
            Debug.Log("race complete");
        }

    }
    // Changes the color of a checkpoint to indicate its status
    void HighlightCheckpoint(Transform checkpoint, Color color)
    {
        Renderer checkpointRenderer = checkpoint.GetComponent<Renderer>();
        if (checkpointRenderer )
        {
            checkpointRenderer.material.color = color;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
