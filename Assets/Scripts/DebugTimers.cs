using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugTimers : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text distanceText;
    private float currentTime;
    
    void Start()
    {
        InvokeRepeating("Timer", 0.1f, Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        // insert if scene is no longer game
        // if(current scene is not game) CancelInvoke("Timer");
        //distanceText.text = DataManager.Instance.GetDistanceTravelled().ToString();
    }

    public void Timer()
    {
        DataManager managerVar = DataManager.Instance;
        var timeVar = managerVar.totalTime;
        currentTime = timeVar;

        var t0 = (int) currentTime;
        var m = t0/60;
        var s = t0 - m*60;
        var ms = (int)((currentTime - t0)*100);
        timeText.text = $"debug; {m:00}:{s:00}:{ms:00}";
    }
}
