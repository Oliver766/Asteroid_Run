using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioOption : MonoBehaviour
{

    [Header("Mixer")]
    [SerializeField] AudioMixer mixer; // mixer reference
    [Header("Sliders")]
    [SerializeField] Slider musicSlider; //slider for main track
    [SerializeField] Slider SFX; // sound effects

    public void Start()
    {
        if (PlayerPrefs.HasKey("MusicV"))
        {
            LoadVolume();
        }
        else
        {
            setMusic();
            setSFX();
        }
    }

    public void setMusic()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicV", volume);
    }

    public void setSFX()
    {
        float volume = SFX.value;
        mixer.SetFloat("SFXVolume", volume);
        PlayerPrefs.SetFloat("SFXV", volume);
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicV");
        SFX.value = PlayerPrefs.GetFloat("SFXV");
        setMusic();
        setSFX();
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
        PlayerPrefs.DeleteKey("num");

    }

}
