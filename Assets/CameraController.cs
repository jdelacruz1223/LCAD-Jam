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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ToggleCameras();
        }
    }

    void ToggleCameras()
    {
        mainCamera.enabled = !mainCamera.enabled;
        currentCam = secondaryCamera;
        secondaryCamera.enabled = !secondaryCamera.enabled;
    }
}
