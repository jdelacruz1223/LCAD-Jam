using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroceryController : MonoBehaviour
{
    [SerializeField] public Transform waypointA;
    [SerializeField] public Transform waypointB;
    [SerializeField] public GameObject groceryObject;
    [SerializeField] public float speed = 2f;
    [SerializeField] public float returnSpeed = 2f;
    public bool interact = false;
    private Transform targetWaypoint;
    private GameUIController uifx;

    void Awake()
    {
        uifx = FindFirstObjectByType<GameUIController>(); // might be wrong choice of find type?
        if (uifx == null) Debug.LogError($"[{gameObject}]: {nameof(uifx)} not found in the scene!");
    }
    void Start()
    {
        targetWaypoint = waypointB;
        interact = false;
    }

    #region interface
    public void Highlight(bool isHighlighted){
        if (uifx != null)
        {
            uifx.Highlight(groceryObject, isHighlighted);
        } 
    }
    #endregion

    void Update()
    {
        // Debug.Log($"interact {interact} ");
        if(!interact)
        {   
            groceryObject.transform.position = Vector3.MoveTowards(groceryObject.transform.position, targetWaypoint.position, speed * Time.deltaTime);
        }
        else
        {
            groceryObject.transform.position = Vector3.MoveTowards(groceryObject.transform.position, waypointA.position, returnSpeed * Time.deltaTime);
        }
        // Debug.Log(groceryObject.transform.position);
        // Debug.Log(waypointA.position);

        if(groceryObject.transform.position == waypointA.position)
        {
            interact = false;
        }
        
    }

    public void SetTrue()
    {
        interact = true;
    }


}
