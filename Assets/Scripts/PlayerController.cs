using System.Collections;
using System.Collections.Generic;
using TMPro;

// #if UNITY_EDITOR
// using UnityEditor;
// #endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region imports
    private Sanity sanity;
    private Camera mainCam;
    private CameraController camControl;
    private GroceryController groceryControl;
    private Baby baby;
    private RaycastController rayControl;
    #endregion

    void Awake()
    {
        sanity = FindFirstObjectByType<Sanity>();
        if (sanity == null) Debug.LogError($"[{gameObject}]: {nameof(sanity)} not found in the scene!");

        camControl = FindFirstObjectByType<CameraController>();
        if (camControl == null) Debug.LogError($"[{gameObject}]: {nameof(camControl)} not found in the scene!");

        groceryControl = FindFirstObjectByType<GroceryController>();
        if (groceryControl == null) Debug.LogError($"[{gameObject}]: {nameof(groceryControl)} not found in the scene!");

        baby = FindFirstObjectByType<Baby>();
        if (baby == null) Debug.LogError($"[{gameObject}]: {nameof(baby)} not found in the scene!");

        rayControl = FindFirstObjectByType<RaycastController>();
        if (rayControl == null) Debug.LogError($"[{gameObject}]: {nameof(rayControl)} not found in the scene!");
    }
    void Update()
    {
        if (camControl != null && camControl.currentCam != null) { MousePointer(camControl.currentCam); }
    }



    #region audio
    public AudioClip shifterSound;
    public AudioClip shutUpBabySound;
    public AudioClip groceryBagSound;
    public AudioClip carWarning;
    #endregion


    #region control
    Animator animator;
    void MouseFunction(GameObject target) //expandable
    {
        if(Input.GetMouseButtonDown(0) && target.CompareTag("SanityMod"))
            {
                // Debug.Log($"Hit: {target.name}");
                switch(target.name)
                {
                    case "shifter":
                        AudioManager.Instance.PlaySound(shifterSound);
                        ToggleDriving(); //insert road behavior here
                        break;
                    case "baby":
                        AudioManager.Instance.PlaySound(shutUpBabySound);
                        sanity.SetToggleState("babyValue", false);
                        // Debug.Log("baby cool");
                        break;
                    case "groceryTransform":
                        AudioManager.Instance.PlaySound(groceryBagSound);
                        groceryControl.SetTrue();
                        // animator.SetTrigger("isGroceryBagging");
                        // Debug.Log("the bag");
                        break;
                    // insert more cases here
                } 
            }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("RoadWarning"))
        {
            Debug.Log("RoadWarning");
            AudioManager.Instance.PlaySound(carWarning);
        } 
        else if(other.CompareTag("RoadDeath"))
        {
            Debug.Log("RoadDeath");
            SceneManager.LoadScene("CrashEnd");
            // sanity.Die();
        }
    }
    void MousePointer(Camera currentCam)
    {
        mainCam = currentCam;
        RaycastHit hit;
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log($"raycast hit {hit}");
            rayControl.CastCheck(hit);
            MouseFunction(rayControl.target);
        }
        else
        {
            rayControl.UnhighlightLastObject();
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
