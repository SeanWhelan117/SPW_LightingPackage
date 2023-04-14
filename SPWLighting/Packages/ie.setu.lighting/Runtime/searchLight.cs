using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class searchLight : MonoBehaviour
{
    public float rotateSpeed = 25f; 
    public float minRotation = -45f; 
    public float maxRotation = 45f; 

    private bool rotatingLeft = true; 
    bool rotating = true;

    private bool followPlayer = false;
    private float startTime = 0f;
    private float followDuration = 2f;

    private GameObject target;
    Light2D light;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        light = GetComponentInChildren<Light2D>();
    }

    void Update()
    {
        if (rotating)
        {
            if (rotatingLeft)
            {
                transform.Rotate(Vector3.forward, -rotateSpeed * Time.deltaTime);

                if (transform.localEulerAngles.z <= 360f + minRotation && transform.localEulerAngles.z > 180f)
                {
                    rotatingLeft = false; 
                }
            }
            else
            {
                transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);

                if (transform.localEulerAngles.z >= maxRotation && transform.localEulerAngles.z < 180f)
                {
                    rotatingLeft = true;
                }
            }
        }
        else
        {
            if (!followPlayer && Time.time - startTime >= followDuration)
            {
                followPlayer = true;
                rotating = false;
                Debug.Log("Follow player");
            }
        }


        if (followPlayer)
        {
            if (target != null)
            {
                light.color = Color.red;
                // get the direction from the rotating object to the target object
                Vector3 direction = target.transform.position - transform.position;

                // calculate the angle between the direction vector and the x-axis
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                angle += 90;
                // set the rotation of the object around the z-axis
                Vector3 eulerAngles = transform.eulerAngles;
                eulerAngles.z = angle;
                transform.eulerAngles = eulerAngles;
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Entered");
            rotating = false;
            startTime = Time.time;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player exited");
            if(followPlayer == false)
            {
                rotating = true;
            }
            startTime = 0f;
            
        }
    }
}
