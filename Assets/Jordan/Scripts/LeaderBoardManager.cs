using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LeaderBoard
{
    public string name;
    public int position;

    public LeaderBoard(string name, int pos)
    {
        this.name = name;
        this.position = pos;    
    }


}

public interface PosCounter
{
    public int counter { get; set; }
}

public class LeaderBoardManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<LeaderBoard> position;
    public GameObject[] cars;
   
   // Playercontroller controller;

    void Start()
    {
        position = new List<LeaderBoard>();
        for (int i = 0; i < cars.Length; i++)
        {
            if (cars[i].GetComponent<RacingAI>())
            {
                RacingAI ai = cars[i].GetComponent<RacingAI>();
                LeaderBoard pos = new LeaderBoard(ai.name, i + 1);
                position.Add(pos);
                Debug.Log(pos.name + ":   "+ pos.position);
            }
        }

       
    }

    public void UpdateList()
    {

        position.Clear();
        List<LeaderBoard> progress = new List<LeaderBoard>();


        foreach (var car in cars)
        {
            int count = 0;
            string Carname = car.name;

            if (car.TryGetComponent<RacingAI>(out var carAi))
            {
                Carname = carAi.name;
                count = carAi.counter;
            }

            LeaderBoard temp = new LeaderBoard(Carname, count);
            progress.Add(temp);
        }
        
         progress.Sort((t, y) => t.position.CompareTo(y.position));

        for (int i = 0; i < progress.Count; i++)
        {
            var pos = new LeaderBoard(progress[i].name, i +1);
            position.Add(pos);
            Debug.Log(pos.name + ":   " + pos.position);
        }
       // for()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
