using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    public AudioMixer mixer;
    public float masterVolume, musicVolume, sfxVolume, uiVolume;

    private GameObject latestUpdated;

	void Awake () {
		if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
	}

    public void SetMasterVolume(float value)
    {
        masterVolume = value;
        mixer.SetFloat("masterVolume", value);
    }

    public void SetMusicVolume(float value)
    {
        musicVolume = value;
        mixer.SetFloat("musicVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        sfxVolume = value;
        mixer.SetFloat("sfxVolume", value);
    }   

    public void SetUIVolume(float value)
    {
        uiVolume = value;
        mixer.SetFloat("uiVolume", value);
    }

    public void UpdateMasterLabel(TextMeshProUGUI label)
    {
        float roundedVal = Round(masterVolume, 2);
        string roundedStr = roundedVal.ToString().Replace(",", ".");

        label.text = roundedVal == 0 ? "0.00" : roundedVal == -80 ? "-80.00" : roundedStr;
    }
    public void UpdateSFXLabel(TextMeshProUGUI label)
    {
        float roundedVal = Round(sfxVolume, 2);
        string roundedStr = roundedVal.ToString().Replace(",", ".");

        label.text = roundedVal == 0 ? "0.00" : roundedVal == -80 ? "-80.00" : roundedStr;
    }

    public void UpdateUILabel(TextMeshProUGUI label)
    {
        float roundedVal = Round(uiVolume, 2);
        string roundedStr = roundedVal.ToString().Replace(",", ".");

        label.text = roundedVal == 0 ? "0.00" : roundedVal == -80 ? "-80.00" : roundedStr;
    }

    public void UpdateMusicLabel(TextMeshProUGUI label)
    {
        float roundedVal = Round(musicVolume, 2);
        string roundedStr = roundedVal.ToString().Replace(",", ".");

        label.text = roundedVal == 0 ? "0.00" : roundedVal == -80 ? "-80.00" : roundedStr;
    }

    public void ToggleSound()
    {
        mixer.ClearFloat
    }

    private float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, digits);
        return Mathf.Round(value * mult) / mult;
    }

}
