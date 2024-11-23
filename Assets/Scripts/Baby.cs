using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Baby : MonoBehaviour
{
    public GameObject player;
    public Sanity playerSanity;
    void Start()
    {
        playerSanity = player.GetComponent<Sanity>();
        StartCoroutine(RandomNumberGenerator());
    }

    IEnumerator RandomNumberGenerator()
    {
        while (true)
        {
            float randomDelay = UnityEngine.Random.Range(2f, 10f);
            yield return new WaitForSeconds(randomDelay);
            EnableBabyDamage();
        }
        
    }

    void EnableBabyDamage()
    {
        if(!playerSanity.GetToggleState("babyValue")) 
        {
            Debug.Log("baby mad");
            playerSanity.SetToggleState("babyValue", true);
        }
    }
}
