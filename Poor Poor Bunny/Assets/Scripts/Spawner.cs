using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    //Spawn spike at random location
    //Drop spike

    public GameObject spikePrefab;
    public float xPositionLimit;
    //public int spawnRate;

	// Use this for initialization
	void Start () {
        //SpawnSpike();
        //StartSpawning();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnSpike()
    {
        float randomX = Random.Range(-xPositionLimit, xPositionLimit);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y,-0.3f);

        Instantiate(spikePrefab, spawnPosition, Quaternion.identity);
    }

    public void StartSpawning(float spawnRate)
    {
        InvokeRepeating("SpawnSpike", 1f, spawnRate);       
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnSpike");
        Debug.Log("stop");
    }
}
