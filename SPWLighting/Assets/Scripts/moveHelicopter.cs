using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHelicopter : MonoBehaviour
{
    public float speed = 5f; 
    public float range = 5f; 

    private float startX;

    private void Start()
    {
        startX = transform.position.x;
    }

    private void Update()
    {
        float newX = startX + Mathf.Sin(Time.time * speed) * range;

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
