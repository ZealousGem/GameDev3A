using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    private AudioSource audioSource;
    private HashMap<string, AudioClip> soundMap;


    [System.Serializable]
    public struct SoundEntry
    {
        public string key;
        public AudioClip clip;
    }

    public SoundEntry[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        audioSource=gameObject.AddComponent<AudioSource>();
        soundMap = new HashMap<string,AudioClip>();

        foreach (var sound in sounds)
        {
            soundMap.Put(sound.key, sound.clip);
        }
    }

    public void PlaySound(string key)
    {
        try
        {
            AudioClip clip = soundMap.Get(key);
            audioSource.PlayOneShot(clip);
        }
        catch (KeyNotFoundException)
        {

        }
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
