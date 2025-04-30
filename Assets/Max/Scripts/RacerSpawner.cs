using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject ARacerPrefab;
    public GameObject BRacerPrefab;
    public GameObject CRacerPrefab;
    private readonly string[] nameSuffixes =
    {
        "Alpha","Turbo","Viper", "Dash","Omega","Thunder"
    };
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] prefabTypes = { ARacerPrefab, BRacerPrefab, CRacerPrefab };
        

        RacerFactory factory = new AIRacerFactory(prefabTypes);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int type = i % 3;

            AIRacer racer = factory.CreateRacer(type);

            GameObject instance = Instantiate(racer.ModelPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
            string uniqueName=racer.RacerName+" "+GetRandomSuffix();
            instance.name = uniqueName;
            //int type = i % 3; // Rotate between 0,1,2
            //AIRacer racer = factory.CreateRacer(type);
            //racer.Initialize();
            //GameObject instance = Instantiate(racer.ModelPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
            //instance.name = racer.RacerName;

            RacingAI racingAI = instance.GetComponent<RacingAI>();
            if (racingAI != null)
            {
                Debug.Log("in racespawner, before change racingAi topspeed is" + racingAI.Topspeed + "and racer speed is" + racer.Speed);
                racingAI.Topspeed = racer.Speed;
                racingAI.BrakeSpeed = racer.Brake;

            }

        }

    }
    private string GetRandomSuffix()
    {
        return nameSuffixes[Random.Range(0, nameSuffixes.Length)];
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
