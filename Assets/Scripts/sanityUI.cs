using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sanityUI : MonoBehaviour
{
    DataManager dataManager;

    public Slider slider;
    int sanityValue;


    // Start is called before the first frame update
    void Start()
    {
        DataManager dataManager = GetComponent<DataManager>();
        sanityValue = dataManager.playerSanity; // initialize with whatever the set value is in DataManager
    }

    void Update()
    {
        sanityValue = dataManager.playerSanity; // *every frame*, read and update what the current Sanity Value is
        SetSanity(sanityValue);
        SetMaxSanity(sanityValue);// pass into slider function
    }

    public void SetMaxSanity(int sanityValue)
    {
        slider.maxValue = sanityValue;
        slider.value = sanityValue;
    }
    public void SetSanity(int sanityValue)
    { slider.value = sanityValue; }
}
