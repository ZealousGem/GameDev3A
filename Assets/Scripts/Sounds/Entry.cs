using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry<K, V>
{

    public K Key { get; } // this is the key that contains a unique identifer for the value
    public V Value { get; set; } // this is the value which will be paired with the key but can be manipulated and deuplicated

    public Entry (K key, V value) // creates a dictionary or a map which contains unique keys and many similar or different values 
    {
        Key = key; Value = value;
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
