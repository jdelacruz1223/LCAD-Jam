using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    
    

    void Awake()
    {

    }

    void Update()
    {
        
        MousePointer();
    }

    void MousePointer()
    {
        Camera mainCam = Camera.main;
        RaycastHit hit;
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            Debug.Log($"Hit: {hit.collider.name}");
        }
        else
        {
            Debug.Log("None");
        }
    }
}
