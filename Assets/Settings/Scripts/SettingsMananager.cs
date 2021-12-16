using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMananager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1);
    }

    public void ChangeMusicVolume(float value)
    {
        mixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, Mathf.Sqrt(value)));
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void ChangeSFXVolume(float value)
    {
        mixer.SetFloat("SFXVolume", Mathf.Lerp(-80, 0, Mathf.Sqrt(value)));
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    public void CloseClick()
    {
        Destroy(gameObject);
    }
}
