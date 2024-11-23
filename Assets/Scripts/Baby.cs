using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;

public class Baby : MonoBehaviour
{
    private Sanity sanity;
    void Start()
    {
        InvokeRepeating("cooldown", 1f, 1f);
    }

    void Update()
    {
        
    }

    

    

}
