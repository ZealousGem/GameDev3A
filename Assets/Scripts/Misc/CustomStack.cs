using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomStack<T>
{

    private List<T> elements = new List<T>();

    public void Push( T item)
    {
        elements.Add(item);

    }

    public T Pop()
    {
        T item = elements[elements.Count - 1];
        // Retrieves the last element in the list (top of the stack)

        elements.RemoveAt(elements.Count - 1);
        // Remove the last element from the list

        return item;
    }

    public T Peek()
    {
        
        return elements[elements.Count - 1];
        // Retrieves the last element in the list (top of the stack)
    }
    public bool IsEmpty()
    {
        return elements.Count == 0;
    }

    public int Count()
    {
        //counts how many elements ther are
        //need to check if this is used
        return elements.Count;
    }
    

    
}
