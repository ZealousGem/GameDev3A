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
        T item = elements[^1];
        elements.RemoveAt(elements.Count - 1);
        return item;
    }

    public T Peek()
    {
        return elements[^1];
    }
    public bool IsEmpty()
    {
        return elements.Count == 0;
    }

    public int Count()
    {
        return elements.Count;
    }
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
