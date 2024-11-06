using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRaising : MonoBehaviour
{
    public float raiseSpeed = 1.0f;  // Speed at which the water will rise
    private float targetHeight = 10.0f;  // Final height you want the water to reach

    void Update()
    {
        if (transform.position.y < targetHeight)
        {
            transform.position += Vector3.up * raiseSpeed * Time.deltaTime;
        }
    }
}
