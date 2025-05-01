using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerSpawner : MonoBehaviour
{
    // Array of spawn locations in the scene
    public Transform[] spawnPoints;

    // Prefabs for each type of AI racer
    public GameObject ARacerPrefab;
    public GameObject BRacerPrefab;
    public GameObject CRacerPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        // Array of prefabs
        GameObject[] prefabTypes = { ARacerPrefab, BRacerPrefab, CRacerPrefab };

        // Create the factory and pass in the prefab list
        RacerFactory factory = new AIRacerFactory(prefabTypes);


        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // Cycle through the 3 racer types using modulo
            int type = i % 3;

            AIRacer racer = factory.CreateRacer(type);

            GameObject instance = Instantiate(racer.ModelPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
            
            instance.name = racer.RacerName;

            // Get the RacingAI component from the spawned object
            RacingAI racingAI = instance.GetComponent<RacingAI>();
            if (racingAI != null)
            {
                //Debug.Log("in racespawner, before change racingAi topspeed is" + racingAI.Topspeed + "and racer speed is" + racer.Speed);
                racingAI.Topspeed = racer.Speed;
                racingAI.BrakeSpeed = racer.Brake;
                racingAI.Carname = racer.RacerName;

            }

        }

    }
    
    
}
