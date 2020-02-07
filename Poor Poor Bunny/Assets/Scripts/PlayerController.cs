﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 0f;
    public float xLimit;

    float xInput;

    Vector2 newPosition;
    Rigidbody2D rb;
    Spawner spawnScript;
    private GameManagerScript manager;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnScript = GameObject.Find("SpikeSpawner").GetComponent<Spawner>();
        manager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }
   
	
	// Update is called once per frame
	void FixedUpdate () {
        MovePlayer();
	}

    void MovePlayer()
    {
        xInput = Input.GetAxis("Horizontal");
        newPosition = transform.position;
        newPosition.x += xInput * moveSpeed;

        //Limits player movement
        newPosition.x = Mathf.Clamp(newPosition.x, -xLimit, xLimit);

        rb.MovePosition(newPosition);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "spike")
        {
           
            manager.GameOver();
            gameObject.SetActive(false);

        }
    }
}