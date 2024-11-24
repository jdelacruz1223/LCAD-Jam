using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelBar : MonoBehaviour
{
    DataManager dataManager;

    [SerializeField] private Image travelBarFill;

    void Start()
    {
        dataManager = FindFirstObjectByType<DataManager>();
    }

    public void UpdateTravelBar()
    {
        float targetFillAmount = dataManager.distanceTravelled / dataManager.finalDestinationTravelledAmount;
        travelBarFill.fillAmount = targetFillAmount;
    }
}
