using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour {
    //if there is a playerprefs value then changes initial value of slider

    public Slider soundSlider;
    public Slider musicSlider;

	// Use this for initialization
	void Start ()
    { 
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }

        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
        }
    }
}
