using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Sanity sanity;
    private Baby baby;
    private DataManager dataManager;
    private Camera mainCam;
    void Awake()
    {
        baby = GetComponent<Baby>();
        sanity = GetComponent<Sanity>();
        dataManager = DataManager.Instance;
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
        mainCam = Camera.main;
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
                    case "shifter":
                        ToggleDriving();
                        break;
                    case "baby":
                        sanity.SetToggleState("babyValue", false);
                        Debug.Log("baby cool");
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

    void ToggleDriving()
    {
        if(dataManager.GetIsDriving())
        {
            Debug.Log("Not Driving");
            dataManager.CancelInvoke("IncreaseDistance");
            sanity.SetToggleState("driveValue", false);
        }
        else if(dataManager.GetIsDriving() == false)
        {
            Debug.Log("Driving");
            dataManager.InvokeRepeating("IncreaseDistance", 1f, 1f);
            sanity.SetToggleState("driveValue", true);
        }
        dataManager.ToggleIsDriving();
    }

    
}
