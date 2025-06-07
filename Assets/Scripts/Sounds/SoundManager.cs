using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    private AudioSource audioSource;
    private AudioSource musicSource;
    private AudioSource carSource;
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
        musicSource=gameObject.AddComponent<AudioSource>();
        carSource=gameObject.AddComponent<AudioSource>();
        musicSource.volume = 0.5f;
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

    public void PlayCarSound(string key)
    {
        try
        {
            AudioClip clip = soundMap.Get(key);
            carSource.clip = clip;
            carSource.loop = true;
            carSource.Play();
        }
        catch { 
        
        }   
    }

    public void StopCarSound(string key)
    {
        try
        {
            if (soundMap.ContainsKey(key))
            {
                carSource.loop = false;
                carSource.Stop();
            }
           
          
        }
        catch (KeyNotFoundException)
        {

        }
    }

    public void PlaySong(string key)
    {
        try
        {
            AudioClip clip = soundMap.Get(key);
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
        catch (KeyNotFoundException)
        {

        }
    }

    public void StopSong()
    {
        try
        {
            musicSource.Stop();
            musicSource.loop = false;
        }

        catch(KeyNotFoundException)
        {

        }
       
    }

    public void ManageMusicVolume(float vol)
    {
        musicSource.volume = vol;
    }

    public void ManageSoundVolume(float vol)
    {
        audioSource.volume = vol;
        carSource.volume = vol - 0.2f;
    }
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlaySong("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
