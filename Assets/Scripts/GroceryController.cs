using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class GroceryController : MonoBehaviour
{
    [SerializeField] public Transform waypointA;
    [SerializeField] public Transform waypointB;
    [SerializeField] public float speed = 2f;
    [SerializeField] public float returnSpeed = 2f;
    public GameObject groceryObject;
    private Transform targetWaypoint;
    public bool interact;
    void Start()
    {
        interact = false;
        targetWaypoint = waypointB;
    }

    void Update()
    {
        // Debug.Log($"interact: {interact}");
        if(!interact)
        {
            groceryObject.transform.position = Vector3.MoveTowards(groceryObject.transform.position, targetWaypoint.position, speed * Time.deltaTime);
        }
        else
        {
            groceryObject.transform.position = Vector3.MoveTowards(groceryObject.transform.position, waypointA.position, returnSpeed * Time.deltaTime);
        }
        
        if(Vector3.Distance(groceryObject.transform.position, waypointA.position) < .01f)
        {
            interact = false;
        }
        // Debug.Log($"groceryObject: {waypointA.position}");
        // Debug.Log($"waypointA: {waypointA.position}");
    }

    public void SetTrue()
    {
        interact = true;
    }
}
