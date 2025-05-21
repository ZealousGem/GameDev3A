using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashMap<K,V>
{

    private const int InitialCapacity = 16;
    private LinkedList<Entry<K,V>>[] buckets;
    // Start is called before the first frame update

    public HashMap()
    {
        buckets = new LinkedList<Entry<K,V>>[InitialCapacity];
    }
    private int GetBucketIndex(K key)
    {
        int hash =key.GetHashCode();
        return Mathf.Abs(hash % buckets.Length);
    }
    public void Put(K key, V value)
    {
        int index = GetBucketIndex(key);
        if (buckets[index] == null)
        {
            buckets[index]=new LinkedList<Entry<K,V>>();
        }
        foreach (var entry in buckets[index])
        {
            if (entry.Key.Equals(key))
            {
                entry.Value = value;
                return;
            }
        }
        buckets[index].AddLast(new Entry<K,V>(key, value));
    }

    public V Get(K key)
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

    public bool ContainsKey(K key)
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
