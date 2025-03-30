using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomQueue <T>
{

    List<T> list = new List<T>();

    public void Clear()
    {
        list.Clear();
        //int Count = list.Count;
        //T Peek = list.Count > 0 ? list[0] : throw new System.InvalidOperationException("Queue is empty"); 
    }

    public void Enqueue(T element)
    {
            list.Add(element);
    }

    public T Dequeue()
    {
        if (list.Count == 0)
        {
            Debug.Log("Queue is Empty");
        }
        T Lastitem = list[0];
        list.RemoveAt(0);
        return Lastitem;
    }

    public int Count => list.Count;
    public T peeking => list.Count > 0 ? list[0]: default(T);
    // Start is called before the first frame update
    
}
