using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float jitter = 1f; 
    public float noiseScale = 1f; 
    public float noiseSpeed = 1f; 

    private float xNoiseOffset; 
    private float yNoiseOffset; 

    void Start()
    {
        // Initialize the Perlin noise offsets
        xNoiseOffset = Random.Range(0f, 100f);
        yNoiseOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        float xNoise = Mathf.PerlinNoise(xNoiseOffset, Time.time * noiseSpeed) - 0.5f;
        float yNoise = Mathf.PerlinNoise(yNoiseOffset, Time.time * noiseSpeed) - 0.5f;
        Vector3 moveDirection = new Vector3(xNoise, yNoise, 0f).normalized;

        Vector3 jitterVector = Random.insideUnitSphere * jitter;
        moveDirection += jitterVector.normalized;

        moveDirection = moveDirection.normalized * speed;

        transform.position += moveDirection * Time.deltaTime;
       // transform.rotation = Quaternion.LookRotation(moveDirection);
    }
}
