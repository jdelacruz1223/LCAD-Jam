using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;

public class Baby : MonoBehaviour
{
    public GameObject player;
    public bool playerSanity;
    void Start()
    {
        playerSanity = player.GetComponent<Sanity>();
        InvokeRepeating("EnableBabyDamage", RandomNumber(), 1f);
        InvokeRepeating("RandomNumber", 5f, 1f);
    }

    void Update()
    {
        
    }

    float RandomNumber()
    {
        return UnityEngine.Random.Range(1,5);
    }

    void EnableBabyDamage()
    {
        // if(playerSanity.GetToggleState("babyValue")) 
        // {
        //     Debug.Log("baby mad");
        //     SetToggleState("babyValue", true);
        }
}
