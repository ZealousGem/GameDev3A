using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashMap<K,V>
{

    private const int InitialCapacity = 16; // an original estimate for the number of elements it will hold at the begining 
    private LinkedList<Entry<K,V>>[] buckets;
    // Start is called before the first frame update

    public HashMap() // contrctuor that will create the hash map object if it hasn't been instatied 
    {
        buckets = new LinkedList<Entry<K,V>>[InitialCapacity];
    }
    private int GetBucketIndex(K key) // calculates index given key is located in the hash map
    {
        int hash =key.GetHashCode();
        return Mathf.Abs(hash % buckets.Length);
    }
    public void Put(K key, V value) // adds the key and value into the linked list 
    {
        int index = GetBucketIndex(key); 
        if (buckets[index] == null)
        {
            buckets[index]=new LinkedList<Entry<K,V>>(); // creates a new linked list if index is null
        }
        foreach (var entry in buckets[index]) // looks for key in the hash map 
        {
            if (entry.Key.Equals(key))
            {
                entry.Value = value; // if it is found the keys value will be instiated 
                return;
            }
        }
        buckets[index].AddLast(new Entry<K,V>(key, value)); // once instaited it will be added to the end of the linkedlist 
    }

    public V Get(K key) // trying to find the key value that is in the hash map linked list 
    {
        int index = GetBucketIndex(key);
        if(buckets[index] != null)
        {
            foreach (var entry in buckets[index])
            {
                if(entry.Key.Equals(key))
                {
                    return entry.Value;
                }

            }
        }
        throw new KeyNotFoundException();
    }

    public bool ContainsKey(K key) // trying to find the key value that is in the hash map linked list 
    {
        int index = GetBucketIndex(key); 
        if (buckets[index] !=null) 
        {
            foreach(var entry in buckets[index])
            {
                if (entry.Key.Equals(key))
                {
                    return true;
                }
            }
        }
        return false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
