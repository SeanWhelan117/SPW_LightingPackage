using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class flashPoliceLights : MonoBehaviour
{
    public Light2D blueLight;
    public Light2D redLight;


    public float flashDuration = 0.5f;
    public float timer = 0.0f;


    private bool isBlueOn = true;
    private bool intensitiesSet = false;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= flashDuration)
        {
            if (!intensitiesSet)
            {
                intensitiesSet = true;
                blueLight.intensity = 3.75f;
                redLight.intensity = 3.75f;
            }
            resetTimer();

            toggleLights();
        }
    }

    void resetTimer()
    {
        timer = 0.0f;
    }

    void toggleLights()
    {
        isBlueOn = !isBlueOn;
        blueLight.enabled = isBlueOn;
        redLight.enabled = !isBlueOn;
    }
}
