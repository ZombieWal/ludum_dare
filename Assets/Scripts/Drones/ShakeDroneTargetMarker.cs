using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeDroneTargetMarker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos =  new Vector3(
            transform.position.x + Mathf.Sin(Time.time * 10f) * .0001f,
            transform.position.y + Mathf.Cos(Time.time * 10f) * .0001f,
            transform.position.z
        );
        transform.position = pos;
    }
}
