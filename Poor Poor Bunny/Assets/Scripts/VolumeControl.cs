using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VolumeControl : MonoBehaviour {

    //public AudioSource music;
    [SerializeField] float musicVolume = 1f;
    private float soundVolume = 1f;
    public AudioSource sounds, music;
    public AudioClip levelUp, scoreAlert, bunnyHurt;
    [SerializeField] Slider musicVolumeSlider, soundVolumeSlider;

	// Use this for initialization
	void Start () {

        sounds = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        music.volume = musicVolume;
        sounds.volume = soundVolume;
	}

    public void SetVolumeMusic(float vol)
    {
        musicVolume = musicVolumeSlider.value;
    }

    public void SetSoundVolume(float vol)
    {
        soundVolume = soundVolumeSlider.value;
    }

    public void LevelUpAudio()
    {
     
        sounds.clip = levelUp;
        sounds.Play();

    }

    public void ScoreAudio()
    {
        
        sounds.clip = scoreAlert;
        sounds.Play();
    }

    public void BunnyHit()
    {
        
        sounds.clip = bunnyHurt;
        sounds.Play();
    }

    private void Load()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        soundVolumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume,", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("soundVolume,", soundVolumeSlider.value);
    }
}
