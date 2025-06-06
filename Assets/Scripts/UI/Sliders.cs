using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sliders : MonoBehaviour
{

    public Slider Slider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Slider.onValueChanged.AddListener((v) => {

            Slider.value = v;


        });
    }

    public void VolumeSound()
    {
        float amount = Slider.value;
        SoundManager.instance.ManageSoundVolume(amount);
    }

    public void VolumeMusic()
    {
        float amount = Slider.value;
        SoundManager.instance.ManageMusicVolume(amount);
    }
}
