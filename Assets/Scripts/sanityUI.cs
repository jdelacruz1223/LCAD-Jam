using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sanityUI : MonoBehaviour
{
    Sanity sanity;
    [Range(0f, 1f)]
    public float alpha = 0f;
    public Slider slider;
    public Image sanityOverlayImage;
    public sanityUI sanityBar;
    float sanityValue;
    int distanceTraveled;
  


    // Start is called before the first frame update
    void Start()
    {
        Sanity sanity = GetComponent<Sanity>();
        float currentSanity = sanity.currentSanity;
        sanityValue = currentSanity;
        distanceTraveled = DataManager.Instance.distanceTravelled;// initialize with whatever the set value is in DataManager

    }

    void Update()
    {
        //sanityValue = sanity.currentSanity; // *every frame*, read and update what the current Sanity Value is
        SetSanity(sanityValue);
        SetMaxSanity(sanityValue);// pass into slider function
        sanityBar.SetMaxSanity(sanityValue);
        sanityOverlayImage.color = new Color(sanityOverlayImage.color.r, sanityOverlayImage.color.g, sanityOverlayImage.color.b, alpha + .1f);
    }

    public void SetMaxSanity(float currentSanity)
    {
        slider.maxValue = sanityValue;
        slider.value = sanityValue;
    }
    public void SetSanity(float currentSanity)
    { 
        slider.value = sanityValue; 
    }
}
