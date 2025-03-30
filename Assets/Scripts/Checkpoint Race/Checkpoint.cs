using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public CheckpointManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<CheckpointManager>();

    }
    private void OnTriggerEnter(Collider other)
    {
        //this is on every checkpoint and ensures that if something collides with the checkpoint 
        //it needs to be tagged player to called the checkpointReached method in CheckpointManager
        if (other.CompareTag("Player"))
        {
            manager.CheckpointReached(transform);
        }
    }
}
