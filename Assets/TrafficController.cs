using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour, RoadTrafficInterface
{
    [SerializeField] float minDriftSpeed;
    [SerializeField] float maxDriftSpeed;
    [SerializeField] int minDelay;
    [SerializeField] int maxDelay;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public float GetRandomSpeed()
    {
        return Random.Range(minDriftSpeed, maxDriftSpeed);
    }

    public float GetRandomDelay()
    {
        return Random.Range(minDelay, maxDelay);
    }
}
