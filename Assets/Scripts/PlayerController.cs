using System.Collections;
using System.Collections.Generic;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region imports
    private Sanity sanity;
    private GroceryController grocery;
    private Camera mainCam;
    #endregion

    

    void Awake()
    {
        sanity = GetComponent<Sanity>();
<<<<<<< Updated upstream
        audioSource = GetComponent<AudioSource>();
=======
        grocery = FindFirstObjectByType<GroceryController>();
        camControl = FindFirstObjectByType<CameraController>();
>>>>>>> Stashed changes
        if (!sanity)
        {
            Debug.LogError("Sanity component not found.");
        }
    }
    void Update()
    {
        MousePointer();
    }

    #region audio
    public AudioClip shifterSound;
    public AudioClip shutUpBabySound;
<<<<<<< Updated upstream
    private AudioSource audioSource;
    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
=======
    public AudioClip groceryBagSound;

>>>>>>> Stashed changes
    #endregion


    



    #region control
<<<<<<< Updated upstream
    void MousePointer()
=======
    [SerializeField] public GameObject groceryObject;
    
    void MousePointer(Camera currentCam)
>>>>>>> Stashed changes
    {
        mainCam = Camera.main;
        RaycastHit hit;
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
<<<<<<< Updated upstream
=======
            // Debug.Log($"Hit: {hit.collider.name}");
>>>>>>> Stashed changes
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            if(Input.GetMouseButtonDown(0) && hit.collider.CompareTag("SanityMod"))
            {
                Debug.Log($"Hit: {hit.collider.name}");
                switch(hit.collider.name)
                {
                    case "shifter":
                        PlaySound(shifterSound);
                        ToggleDriving();
                        break;
                    case "baby":
                        PlaySound(shutUpBabySound);
                        sanity.SetToggleState("babyValue", false);
                        Debug.Log("baby cool");
                        break;
                    case "groceryTransform":
                        AudioManager.Instance.PlaySound(groceryBagSound);
                        grocery.SetTrue();
                        Debug.Log("the bag");
                        break;
                    // insert more cases here
                }
            } 
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
