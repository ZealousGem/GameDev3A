using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance; // makes the SoundManager a singleton

    private AudioSource audioSource; // audio source that will be used to play the sound from key in the hash map 
    private AudioSource musicSource;
    private AudioSource carSource;
    private HashMap<string, AudioClip> soundMap; // has map of all the contained sounds key name and value in the map 


    [System.Serializable]
    public struct SoundEntry // a struct that will be used to instaite the string name of the clip and clip itself into the hash map
    {
        public string key;
        public AudioClip clip;
    }

    public SoundEntry[] sounds;

    private void Awake() // destorys the object and creates a new everytime a scene is trnaistioned 
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

        audioSource=gameObject.AddComponent<AudioSource>(); // creates an audio source for the keys to be played 
        musicSource=gameObject.AddComponent<AudioSource>();
        carSource=gameObject.AddComponent<AudioSource>();
        musicSource.volume = 0.5f;
        soundMap = new HashMap<string,AudioClip>();

        foreach (var sound in sounds) // adds all the string name as the key and the clip as the value into the hash map 
        {
            soundMap.Put(sound.key, sound.clip);
        }
    }

    public void PlaySound(string key) // plays the auio by finding the key 
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

    public void PlayCarSound(string key)//plays the auio by finding the key 
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

    public void StopCarSound(string key)// will stop playing the audio by findind the key in the hash map 
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

    public void PlaySong(string key) // plays the music by finding the key in the hash map 
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

    public void StopSong() // will stop playing the audio by findind the key in the hash map 
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

    public void ManageMusicVolume(float vol) // manages the vloume of the audio source 
    {
        musicSource.volume = vol;
    }

    public void ManageSoundVolume(float vol) // manages the vloume of the audio source 
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
