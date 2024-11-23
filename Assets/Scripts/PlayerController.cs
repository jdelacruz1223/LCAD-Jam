using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region imports
    private Sanity sanity;
    private Baby baby;
    private Camera mainCam;
    #endregion
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

    



    #region control
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

        if (DataManager.Instance.GetIsDriving())
        {
            Debug.Log("Not Driving");
            DataManager.Instance.CancelInvoke("IncreaseDistance");
            sanity.SetToggleState("driveValue", false);
        }
        else
        {
            Debug.Log("Driving");
            DataManager.Instance.InvokeRepeating("IncreaseDistance", 1f, 1f);
            sanity.SetToggleState("driveValue", true);
        }
        
        DataManager.Instance.ToggleIsDriving();
    }

    #endregion

    
}
