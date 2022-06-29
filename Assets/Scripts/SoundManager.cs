using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    //variabel slider dan convert volume level
    private AudioSource AudioSource;
    private float musicVolume = 1f;


    public Slider volumeSlider;
    public GameObject ObjectMusic;


    void Start()
    {
        //AudioSource.Play();
        ObjectMusic = GameObject.FindWithTag("Music");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        //set volume
        musicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = musicVolume;
        volumeSlider.value = musicVolume;
    }

    void Update()
    {
        AudioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }


}
