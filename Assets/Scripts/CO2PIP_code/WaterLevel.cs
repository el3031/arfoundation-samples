using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class WaterLevel : MonoBehaviour
{
    [SerializeField] private Text WaterLevelMarker;
    public void OnSliderDrag(float value)
    {
        Debug.Log("drag");

        /******** START changing water plane level ********/
        float height = value;

        float timer = 1f;
        float currentTime = 0f;

        Vector3 newPos = new Vector3(transform.position.x, height, transform.position.z);
        while (currentTime < timer)
        {
            currentTime += Time.deltaTime;
            Debug.Log("changing position");
            transform.position = Vector3.Lerp(transform.position, newPos, currentTime / timer);
        }
        /******** END changing water plane level ********/

        /******** START update GUI on side of screen ********/
        WaterLevelMarker.text = value.ToString() + " meters";
        /******** END update GUI on side of screen ********/
    }
}
