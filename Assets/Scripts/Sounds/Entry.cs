using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry<K, V>
{

    public K Key { get; }
    public V Value { get; set; }

    public Entry (K key, V value)
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
