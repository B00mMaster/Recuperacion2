using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class VolumeSettings : MonoBehaviour
{
   
    public AudioMixer audioMixer;
    public Slider musicSlider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))//verify musicVolume exist
        {
            LoadVolume();
        }
        else
        {
            MusicVolume();
        }
        
    }

    public void MusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music",Mathf.Log10(volume)*20);//calculate log volume scale and transform itfrom dB to linear scale

        PlayerPrefs.SetFloat("musicVolume", volume );
    }

    void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");//store slider value
        MusicVolume();
    }
}
