using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Color targetColor = Color.green; // Active checkpoint color
    public Color visitedColor = Color.gray; // Checkpoint already visited
    public Color unvisitedColor = Color.red; // Not yet reached

    public CheckpointManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<CheckpointManager>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.CheckpointReached(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
