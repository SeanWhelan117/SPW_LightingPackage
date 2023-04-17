using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class FireflyBlink : MonoBehaviour
{
    public float minBlinkInterval = 0.1f; 
    public float maxBlinkInterval = 0.5f; 

    private Light2D fireflyLight; 
    private float nextBlinkTime; 

    void Start()
    {
        fireflyLight = GetComponentInChildren<Light2D>();

        nextBlinkTime = Time.time + Random.Range(minBlinkInterval, maxBlinkInterval);
    }

    void Update()
    {
        if (Time.time >= nextBlinkTime)
        {
            fireflyLight.enabled = !fireflyLight.enabled;
            nextBlinkTime = Time.time + Random.Range(minBlinkInterval, maxBlinkInterval);
        }
    }
}
