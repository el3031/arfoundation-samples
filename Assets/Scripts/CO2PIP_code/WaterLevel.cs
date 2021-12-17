using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class WaterLevel : MonoBehaviour
{
    void Start()
    {
        
    }

    public void OnSliderDrag(float value)
    {
        float height = value;

        float timer = 1f;
        float currentTime = 0f;

        Vector3 newPos = new Vector3(transform.position.x, height, transform.position.z);
        while (currentTime < timer)
        {
            currentTime += Time.deltaTime;
            
            transform.position = Vector3.Lerp(transform.position, newPos, currentTime / timer);
        }
    }
}