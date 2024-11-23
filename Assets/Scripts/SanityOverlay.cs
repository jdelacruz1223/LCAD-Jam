using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityOverlay : MonoBehaviour
{
    DataManager dataManager;
    //public Image sanityOverlayStatic;
    public RawImage sanityOverlay;
    [Range(0f, 1f)]
    public float alpha = 1;
    private float sanityTimer;
    private const float SANITY_TIMER_MAX = .5f;
    int sanityValue;
    void Start()
    {
        DataManager dataManager = GetComponent<DataManager>();
        sanityValue = dataManager.playerSanity;
        sanityOverlay = GetComponent<RawImage>();
        sanityOverlay.color = new Color(sanityOverlay.color.r, sanityOverlay.color.g, sanityOverlay.color.b, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        //if (sanityValue < 50)
        {
            //sanityOverlayStatic.color = new Color(sanityOverlayStatic.color.r, sanityOverlayStatic.color.g, sanityOverlayStatic.color.b, alpha);
            //sanityTimer += Time.deltaTime;
            //if (sanityTimer >= SANITY_TIMER_MAX)
            {
              //  sanityOverlay.color = new Color(sanityOverlay.color.r, sanityOverlay.color.g, sanityOverlay.color.b, alpha + .1f);
            }
        }
    }
}
