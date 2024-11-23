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
    private Camera mainCam;
    private CameraController camControl;
    #endregion

    

    void Awake()
    {
        sanity = GetComponent<Sanity>();
        camControl = FindFirstObjectByType<CameraController>();
        if (!sanity)
        {
            Debug.LogError("Sanity component not found.");
        }
    }
    void Update()
    {
        
        if (camControl != null && camControl.currentCam != null)
        {
            MousePointer(camControl.currentCam);
        }
    }

    #region audio
    public AudioClip shifterSound;
    public AudioClip shutUpBabySound;
    // private AudioSource audioSource;
    // void PlaySound(AudioClip clip)
    // {
    //     if (audioSource != null && clip != null)
    //     {
    //         audioSource.PlayOneShot(clip);
    //     }
    // }
    #endregion


    



    #region control
    void MousePointer(Camera currentCam)
    {
        mainCam = currentCam;
        RaycastHit hit;
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log($"Hit: {hit.collider.name}");
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            if(Input.GetMouseButtonDown(0) && hit.collider.CompareTag("SanityMod"))
            {
                Debug.Log($"Hit: {hit.collider.name}");
                switch(hit.collider.name)
                {
                    case "shifter":
                        AudioManager.Instance.PlaySound(shifterSound);
                        ToggleDriving();
                        break;
                    case "baby":
                        AudioManager.Instance.PlaySound(shutUpBabySound);
                        sanity.SetToggleState("babyValue", false);
                        Debug.Log("baby cool");
                        break;
                    // insert more cases here
                }
                
            }
            
        }
        // else
        // {
        //     // Debug.Log("None");
        // }
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
