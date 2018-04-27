using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    public AudioMixer mixer;
    public float masterVolume, musicVolume, sfxVolume, uiVolume;

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
        mixer.
    }
	
}
