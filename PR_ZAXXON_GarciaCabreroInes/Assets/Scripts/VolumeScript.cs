using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeScript : MonoBehaviour
{
    public Slider volSlider;
    public AudioMixer mixer;
    
    void Start()
    {
        volSlider.value = PlayerPrefs.GetFloat("MasterVol", 0.75f);
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVol", sliderValue);
    }


}
