using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class WaterLevel : MonoBehaviour
{
    [SerializeField] private Text WaterLevelMarker;

    private bool meshModified = false;
    private Mesh waterMesh;

    void Start()
    {
    	waterMesh = GetComponent<MeshFilter>().mesh;
        Renderer ren = GetComponent<Renderer>();
        rendr.material.renderQueue = 2002;
    }
    
    /********
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("colliding");
        if (!meshModified)
        {
           	Debug.Log("remodeling mesh"); 
            RemodelMesh(other);
        }
    }

    void RemodelMesh(Collision other)
    {
        List<Vector3> verticesList = new List<Vector3>();
        waterMesh.GetVertices(verticesList);
        int verticesCount = verticesList.Count;
        Debug.Log(verticesCount);
        ContactPoint[] contacts = new ContactPoint[verticesCount];
        other.GetContacts(contacts);

        Vector3[] collisionPoints = new Vector3[verticesCount];
        for (int i = 0; i < contacts.Length; i++)
        {
            collisionPoints[i] = contacts[i].point;
        }

        waterMesh.SetVertices(collisionPoints);
        meshModified = true;
    }
    ********/
    
    public void OnSliderDrag(float value)
    {

        /******** START changing water plane level ********/
        float height = value;

        float timer = 1f;
        float currentTime = 0f;

        Vector3 newPos = new Vector3(transform.position.x, height, transform.position.z);
        while (currentTime < timer)
        {
            currentTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, newPos, currentTime / timer);
        }
        /******** END changing water plane level ********/

        /******** START update GUI on side of screen ********/
        WaterLevelMarker.text = value.ToString() + " meters";
        /******** END update GUI on side of screen ********/
    }
}
