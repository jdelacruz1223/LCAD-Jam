using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Data Manager Singleton Instance
    public static DataManager Instance;
    // private DataManager() {}

    // Timer
    public float totalTime { get; private set; }
    public float startTime { get; private set; }
    private bool isTimerRunning;
    private bool isDriving;

    // Progress
    public int distanceTravelled;
    
    public bool GetIsDriving()
    {
        return isDriving;
    }

    public void ToggleIsDriving()
    {
        isDriving = !isDriving;
    }

    public int GetDistanceTravelled()
    {
        return distanceTravelled;
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

    void Start()
    {
        InitializeGame();
    }

    void Update()
    {
        totalTime = GetTotalTimeElapsed();
    }

    void InitializeGame()
    {
        totalTime = 0;
        startTime = Time.time;
        isTimerRunning = true;
        isDriving = false;
        distanceTravelled = 0;
    }

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
        if(isTimerRunning)
        {
            startTime = Time.time - GetTotalTimeElapsed();
            isTimerRunning = true; 
        }
    }

    public void IncreaseDistance()
    {
        distanceTravelled++;
    }


}
