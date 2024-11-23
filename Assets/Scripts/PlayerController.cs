using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Sanity sanity;
    Baby baby;
    void Awake()
    {
        baby = GetComponent<Baby>();
        sanity = GetComponent<Sanity>();
        if (!sanity)
        {
            Debug.LogError("Sanity component not found.");
        }
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
            if(Input.GetMouseButtonDown(0) && hit.collider.CompareTag("SanityMod"))
            {
                Debug.Log($"Hit: {hit.collider.name}");
                switch(hit.collider.name)
                {
                    case "baby":
                        sanity.SetToggleState("babyValue", false);
                        break;
                    // insert more cases here
                }
                
            }
            
        }
        else
        {
            // Debug.Log("None");
        }
    }

    
}
