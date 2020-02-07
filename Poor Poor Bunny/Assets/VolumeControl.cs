using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour {

    //public AudioSource music;
    private float musicVolume = 1f;
    private float soundVolume = 1f;
    public AudioSource sounds;
    public AudioClip levelUp, scoreAlert, bunnyHurt;

	// Use this for initialization
	void Start () {

        sounds = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //music.volume = musicVolume;
        // sounds.volume = soundVolume;
	}

    public void SetVolumeMusic(float vol)
    {
        musicVolume = vol;
    }

    public void SetSoundVolume(float vol)
    {
        soundVolume = vol;
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
}
