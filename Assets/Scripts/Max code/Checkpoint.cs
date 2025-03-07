using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<CheckpointManager>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            manager.CheckpointReached(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
