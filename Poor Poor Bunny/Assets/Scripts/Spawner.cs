using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject spikePrefab;
    public float xPositionLimit;

	void Start () {
        //SpawnSpike();
        //StartSpawning();
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
