using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


[System.Serializable]
public class LeaderBoard // a struct that contains the drivers information on the leader board
{
    public string name;
    public int position;
    public float distanceFromWaypoint;

    public LeaderBoard(string name, int pos, float dist) // this contructor will instatite all the variables needed to contain the leader board 
    {
        this.name = name;
        this.position = pos;    
        this.distanceFromWaypoint = dist;
    }


}

public interface PosCounter // an interface that can bed used to track the ai and player without making new variables
{
    public int counter { get; set; }
    public float DistancefromWaypoint{get; set;}
    public string name {  get; set; }

  
}

public class LeaderBoardManager : MonoBehaviour
{
    // Start is called before the first frame update
   [HideInInspector]
    public List<LeaderBoard> position;
    public GameObject[] cars; // cars in the race
    PosUIManager ui; // ui that will display the leader board 

  

    void Start()
    {

        StartCoroutine(AddtoLeaderBoard());
       
       

        position = new List<LeaderBoard>();
       
        for (int i = 0; i < cars.Length; i++)
        {
            if (cars[i].GetComponent<RacingAI>()) // finds the car objects and adds them to the leaderboard list 
            {
                RacingAI ai = cars[i].GetComponent<RacingAI>();
                LeaderBoard pos = new LeaderBoard(ai.Carname, i + 1, ai.DistancefromWaypoint);
                position.Add(pos);
               // Debug.Log(pos.name + ":   "+ pos.position);
            }

            else if (cars[i].GetComponent<PlayerWaypointChecker>()) // finds the car objects and adds them to the leaderboard list 
            {
                PlayerWaypointChecker ai = cars[i].GetComponent<PlayerWaypointChecker>();
                LeaderBoard pos = new LeaderBoard(ai.Carname, i + 1, ai.DistancefromWaypoint);
                position.Add(pos);
              //  Debug.Log(pos.name + ":   " + pos.position);
            }


        }

        ui = GameObject.FindWithTag("EditorOnly").GetComponent<PosUIManager>();
        
        ui.LeaaderBoardUpdate(position); // updates leaderboard ui
    }

    public IEnumerator AddtoLeaderBoard()
    {
        yield return null;
        List<GameObject> Tempcars = new List<GameObject>(GameObject.FindGameObjectsWithTag("Cars"));
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Tempcars.Add(Player);
        cars = Tempcars.ToArray();
    }

    public void UpdateList()
    {

        position.Clear(); // clears old leaderboard data from list to create new postions in leaderboard
        List<LeaderBoard> progress = new List<LeaderBoard>(); // creates a temp list so it can be rearranged and sorted to easily trnasfer data to position list 


        foreach (var car in cars) // will loop the car objects to see which is an ai and which is the player
        {
            int count = 0;
            string Carname = car.name;
            float dist = 0;

            if (car.TryGetComponent<RacingAI>(out var carAi)) // if it is the ai it will try and find the variables from that class to add to the leaderboard
            {
                Carname = carAi.name;
                count = carAi.counter;
                dist = carAi.DistancefromWaypoint;
            }

            else if (car.TryGetComponent<PlayerWaypointChecker>(out var Player))
            {
                Carname = Player.name;
                count = Player.counter;
                dist = Player.DistancefromWaypoint;
            }

            LeaderBoard temp = new LeaderBoard(Carname, count, dist); // once found the data from the ai or the player will be added into a new list with the struct
            progress.Add(temp);
        }
        
         progress.Sort((t, y) => {  // this will compare the waypoint counter and distance the cars are from each other to deterime which position they will be in
         
         int CountCompare = y.position.CompareTo(t.position);
         if(CountCompare == 0)
             
                 return t.distanceFromWaypoint.CompareTo(y.distanceFromWaypoint);
                 return CountCompare; // once that is done it will rearrange the data into a sorted order
             
         
         });

        for (int i = 0; i < progress.Count; i++) // once the progress list has been resorted it will then be instatied by the position list 
        {
            var pos = new LeaderBoard(progress[i].name, i +1, progress[i].distanceFromWaypoint);
            position.Add(pos);
           // Debug.Log(pos.name + ":   " + pos.position);
        }

        for (int i = 0; i < cars.Length; i++) // displays the ui position number on the cars and the players ui
        {
            ui.ChangePosUI(cars[i]);
        }

        ui.LeaaderBoardUpdate(position); // updates the leaderboard ui
        // for()
    }

    // Update is called once per frame
    
}
