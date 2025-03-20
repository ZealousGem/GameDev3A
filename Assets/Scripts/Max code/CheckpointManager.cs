using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    public RaceTimer raceTimer;
    public float timeBonus = 5f;

    public List<Transform> CheckpointTransforms;
    private CustomStack<Transform> checkpointStack;
    private Transform currentCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        checkpointStack = new CustomStack<Transform>();

        for (int i =CheckpointTransforms.Count - 1;i >=0; i--)
        {
            checkpointStack.Push(CheckpointTransforms[i]);
        }
        SetNextCheckpoint();

    }
    void SetNextCheckpoint()
    {
        if (!checkpointStack.IsEmpty())
        {
            currentCheckpoint = checkpointStack.Peek();
            HighlightCheckpoint(currentCheckpoint, Color.green);
        }
        else
        {
            Debug.Log(" Race Completed!");
            raceTimer.raceActive = false;

        }

    }

    public Transform GetNextCheckpoint()
    {
        return currentCheckpoint;
        
    }

    public void CheckpointReached(Transform checkpoint)
    {
        if (checkpoint ==checkpointStack.Peek())
        {
            checkpointStack.Pop();
            Debug.Log("checkpoint reached:" + checkpoint.name);


            raceTimer.AddTime(timeBonus);

            HighlightCheckpoint(checkpoint, Color.gray);

            Destroy(checkpoint.gameObject);

            SetNextCheckpoint();

        }
        if (checkpointStack.IsEmpty())
        {
            Debug.Log("race complete");
        }

    }
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
