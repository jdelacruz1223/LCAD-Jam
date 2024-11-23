using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private DataManager() {}
    void Start()
    {
        InitializeGame();
    }
    void InitializeGame()
    {
        totalTime = 0;
        startTime = Time.time;
        isTimerRunning = true;
        isDriving = false;
        distanceTravelled = 0;
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
    public void IncreaseDistance()
    {
        distanceTravelled++;
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
        if(isTimerRunning)
        {
            startTime = Time.time - GetTotalTimeElapsed();
            isTimerRunning = true; 
        }
    }

    #endregion
}
