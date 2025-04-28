using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;


[System.Serializable]
public class CustomLinkedList 
{
    // Start is called before the first frame update

    public WayPointNode head; // begining of the list
    public WayPointNode tail; // end of the list

    public void Add(WayPointNode NodeNew) // adds a new node into the linked list 
    {
        if (head == null) // will make a new head node if list is empty
        {
            head = NodeNew;
            tail = NodeNew;
        }

        else // adds the tail as the new node increasing the lists size 
        {
            tail.nextNode = NodeNew;
            tail = NodeNew;
        }
    }

    public int Count() // goss through the linkedlist in a ciruclar motion 
    {
        int count = 0;
        WayPointNode cur = head;
        for (int i = 0; cur != null && i < int.MaxValue; i++) // will loop until it reaches the head node meaning the list has looped, it will also loop until it reaches the integers max val
        {
            count++;
            cur = cur.nextNode;

            // If loop goes  back to the head, break the loop
            if (cur == head)
                break;
        }

        return count; // returns the nodes position in the linked list 
    }

    public WayPointNode NodeAcess(int elemnt) // acesses the node in the list 
    {
        if (head == null) return null;
        WayPointNode node = head;

        for (int i = 0; i < elemnt; i++) // sets the next node in the index 
        {
            node = node.nextNode;
            if (node.nextNode == head)
            {
                return null; // will make the node null if the loop has gone back to the head 
            }
        }

        return node; // retuns elemente postioned node from linked list
    }
  
}
