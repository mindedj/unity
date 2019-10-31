using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{

    
    private Transform tr;
    public Vector3 offset = new Vector3(0.005f,0,0);

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    
    void Update()
    {

        Vector3 newCamPos = tr.position;
        tr.position = newCamPos + offset;
    }
}
