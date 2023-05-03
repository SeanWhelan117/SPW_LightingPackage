using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFireflies : MonoBehaviour
{
    public GameObject firefly;

    public float spawnInterval = 2.5f;
    public int numberOfFireflies = 150;
   
    public float yPos = -1.0f;
    
    public float minXPos = -10f;
    public float maxXPos = 10f;

    private int firefliesSpawned = 0;

    void Start()
    {
        StartCoroutine(SpawnFireflies());
    }

    IEnumerator SpawnFireflies()
    {
        while (firefliesSpawned < numberOfFireflies)
        {
            Vector3 spawnPos = new Vector3(Random.Range(minXPos, maxXPos), yPos, transform.position.z);
            Instantiate(firefly, spawnPos, Quaternion.identity);
            firefliesSpawned++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
