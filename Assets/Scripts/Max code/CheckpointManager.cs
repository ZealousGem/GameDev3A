using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    public List<Transform> CheckpointTransforms;
    private CustomStack<Transform> checkpointStack;
    // Start is called before the first frame update
    void Start()
    {
        checkpointStack = new CustomStack<Transform>();

        for (int i =CheckpointTransforms.Count - 1;i >=0; i--)
        {
            checkpointStack.Push(CheckpointTransforms[i]);
        }
        
    }
    public Transform GetNextCheckpoint()
    {
        return checkpointStack.Peek();
    }

    public void CheckpointReached(Transform checkpoint)
    {
        if (checkpoint ==checkpointStack.Peek())
        {
            checkpointStack.Pop();
            Debug.Log("checkpoint reached:" + checkpoint.name);
            Destroy(checkpoint.gameObject);

        }
        if (checkpointStack.IsEmpty())
        {
            Debug.Log("race complete");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
