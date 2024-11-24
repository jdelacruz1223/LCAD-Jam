using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondaryCamera;
    public Camera currentCam;
    void Start()
    {
        mainCamera.enabled = true;
        currentCam = mainCamera;
        secondaryCamera.enabled = false;
    }

    void Update()
    {
        ToggleCameras();
    }

    void ToggleCameras()
    {
        if(Input.GetKeyDown(KeyCode.Space) && mainCamera.enabled == true)
        {
            mainCamera.enabled = false;
            secondaryCamera.enabled = true;
            currentCam = secondaryCamera;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && mainCamera.enabled == false)
        {
            mainCamera.enabled = true;
            secondaryCamera.enabled = false;
            currentCam = mainCamera;
        }
        
    }
}
