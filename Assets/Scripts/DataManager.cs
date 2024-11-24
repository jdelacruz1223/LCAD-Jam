using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public TravelBar travelBar;


    // private DataManager() {}
    void Start()
    {
        InitializeGame();
        travelBar = FindFirstObjectByType<TravelBar>();
    }
    void InitializeGame()
    {
        totalTime = 0;
        startTime = Time.time;
        isTimerRunning = true;
        isDriving = false;
        distanceTravelled = 0;

        InvokeRepeating("IncreaseDistance", 1f, 1f);
    }
    void Update()
    {
        totalTime = GetTotalTimeElapsed();
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }




    #region driving
    private bool isDriving;
    public float distanceTravelled;
    public float finalDestinationTravelledAmount = 100;

    public bool GetIsDriving()
    {
        return isDriving;
    }

    public void ToggleIsDriving()
    {
        isDriving = !isDriving;
    }

    public float GetDistanceTravelled()
    {
        return distanceTravelled;
    }
    public void IncreaseDistance()
    {
        distanceTravelled++;

        travelBar.UpdateTravelBar();


        if (distanceTravelled >= finalDestinationTravelledAmount)
        {
            //Win!
        }
    }
    #endregion




    #region Timer
    public float totalTime { get; private set; }
    public float startTime { get; private set; }
    private bool isTimerRunning;
    public float GetTotalTimeElapsed()
    {
        return Time.time - startTime;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void StartTimer()
    {
        if (isTimerRunning)
        {
            startTime = Time.time - GetTotalTimeElapsed();
            isTimerRunning = true;
        }
    }

    #endregion

    #region endings
    public Dictionary<string, bool> endingsTracker = new Dictionary<string, bool>()
    {
        {"Cigarette", false},
        {"Sanity", false},
        {"Grocery", false},
        {"True", false},

    };
    public void SetToggleState(string key, bool state)
    {
        if (endingsTracker.ContainsKey(key))
        {
            endingsTracker[key] = state;
            Debug.Log($"Set {key} to {state}");
        }
        else
        {
            Debug.LogWarning($"Key '{key}' not found in endingsTracker dictionary.");
        }
    }

    public bool GetToggleState(string key)
{
    if (endingsTracker.ContainsKey(key))
    {
        return endingsTracker[key]; // Return the value for the key
    }
    else
    {
        Debug.LogWarning($"Key '{key}' not found in endingsTracker dictionary.");
        return false; // Return default value if key is not found
    }
}
    #endregion
}
