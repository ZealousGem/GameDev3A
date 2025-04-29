using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LeaderBoard
{
    public string name;
    public int position;
    public float distanceFromWaypoint;

    public LeaderBoard(string name, int pos, float dist)
    {
        this.name = name;
        this.position = pos;    
        this.distanceFromWaypoint = dist;
    }


}

public interface PosCounter
{
    public int counter { get; set; }
    public float DistancefromWaypoint{get; set;}
    public string name {  get; set; }
}

public class LeaderBoardManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<LeaderBoard> position;
    public GameObject[] cars;
    PosUIManager ui;

    // Playercontroller controller;

    void Start()
    {
        position = new List<LeaderBoard>();
       
        for (int i = 0; i < cars.Length; i++)
        {
            if (cars[i].GetComponent<RacingAI>())
            {
                RacingAI ai = cars[i].GetComponent<RacingAI>();
                LeaderBoard pos = new LeaderBoard(ai.Carname, i + 1, ai.DistancefromWaypoint);
                position.Add(pos);
                Debug.Log(pos.name + ":   "+ pos.position);
            }
        }

        ui = GameObject.FindWithTag("EditorOnly").GetComponent<PosUIManager>();
        ui.LeaaderBoardUpdate(position);
    }

    public void UpdateList()
    {

        position.Clear();
        List<LeaderBoard> progress = new List<LeaderBoard>();


        foreach (var car in cars)
        {
            int count = 0;
            string Carname = car.name;
            float dist = 0;

            if (car.TryGetComponent<RacingAI>(out var carAi))
            {
                Carname = carAi.name;
                count = carAi.counter;
                dist = carAi.DistancefromWaypoint;
            }

            LeaderBoard temp = new LeaderBoard(Carname, count, dist);
            progress.Add(temp);
        }
        
         progress.Sort((t, y) => { 
         
         int CountCompare = y.position.CompareTo(t.position);
         if(CountCompare == 0)
             
                 return t.distanceFromWaypoint.CompareTo(y.distanceFromWaypoint);
                 return CountCompare;
             
         
         });

        for (int i = 0; i < progress.Count; i++)
        {
            var pos = new LeaderBoard(progress[i].name, i +1, progress[i].distanceFromWaypoint);
            position.Add(pos);
           // Debug.Log(pos.name + ":   " + pos.position);
        }

        for (int i = 0; i < cars.Length; i++)
        {
            ui.ChangePosUI(cars[i]);
        }

        ui.LeaaderBoardUpdate(position);
        // for()
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
