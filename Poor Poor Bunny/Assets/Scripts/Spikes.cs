using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spikes : MonoBehaviour {

    public float rotateSpeed;
    public VolumeControl sound;
    private GameManagerScript manager;
    
  
	// Use this for initialization
	void Start () {
        manager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.Rotate(0, 0, rotateSpeed);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            sound = GameObject.Find("GameSounds").GetComponent<VolumeControl>();
            sound.ScoreAudio();
            //manager.AddScore(1);
            manager.Score = 1;
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            sound = GameObject.Find("GameSounds").GetComponent<VolumeControl>();
            sound.BunnyHit();
        }
    }
}
