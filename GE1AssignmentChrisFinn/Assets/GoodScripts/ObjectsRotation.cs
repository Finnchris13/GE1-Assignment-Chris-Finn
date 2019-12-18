﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsRotation : MonoBehaviour
{
    public GameObject discoBall;

    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        discoBall.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

 
    }

}
