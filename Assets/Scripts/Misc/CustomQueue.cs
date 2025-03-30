using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomQueue <T>
{

    List<T> list = new List<T>(); // This is where all the elements are contained

    public void Clear()
    {
        list.Clear(); // clears any remianing elements in the queue
        
    }

    public void Enqueue(T element)
    {
            list.Add(element); // adds all the elements into the queue
    }

    public T Dequeue()
    {
        if (list.Count == 0)
        {
            Debug.Log("Queue is Empty");
        }
        T Lastitem = list[0];
        list.RemoveAt(0); // when the element in the fonr of the queue list is dequeue it is removed from the list 
        return Lastitem;
    }

    public int Count => list.Count; // accesser the displays the size of the queue
    public T peeking => list.Count > 0 ? list[0]: default(T); // peeks through the first lelemnt in the queue list 
   
    
}
