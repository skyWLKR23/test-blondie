using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioManager instance;

    private AudioSource melodie;
    private AudioSource[] sounds;//0-melodie, 1-click, 2-click_buttons_categories, 3-particles, 4-snapshot

    private float musicVolume = 1f;
    private float soundVolume = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            sounds = this.GetComponents<AudioSource>();
            melodie = sounds[0];
            melodie.loop = true;
            melodie.Play();

            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            }

            if(PlayerPrefs.HasKey("SoundVolume"))
            {
                soundVolume = PlayerPrefs.GetFloat("SoundVolume");
            }
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        if (melodie.volume != musicVolume)
        {
            melodie.volume = musicVolume;
        }
        if (sounds[1].volume != soundVolume)
        {
            for (int i = 1; i < 5; i++)
            {
                sounds[i].volume = soundVolume;
            }
        }
    }

    public void SetMusicVolume(float vol)//changes between 0 and 1
    {
        musicVolume = vol;
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void SetSoundVolume(float vol)
    {
        soundVolume = vol;
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
    }

    public void playClick()
    {
        sounds[1].Play();
    }
    
    public void playClickCategorii()
    {
        sounds[2].Play();
    }

    public void playParticles()
    {
        sounds[3].Play();
    }

    public void playSnapShot()
    {
        sounds[4].Play();
    }
}
