using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroceryController : MonoBehaviour
{
    [SerializeField] public Transform waypointA;
    [SerializeField] public Transform waypointB;
    [SerializeField] public float speed = 2f;
    private Transform targetWaypoint;
    void Start()
    {
        targetWaypoint = waypointB;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
    }
}
