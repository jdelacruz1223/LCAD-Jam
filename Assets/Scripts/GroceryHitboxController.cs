using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroceryHitboxController : MonoBehaviour
{
    private Sanity sanity;

    void Start()
    {
        sanity = FindFirstObjectByType<Sanity>();
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bags dropped, Death");
        sanity.Die();
    }

    
}
