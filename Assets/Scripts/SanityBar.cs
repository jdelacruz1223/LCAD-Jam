using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    Sanity sanity;

    [SerializeField] private Image sanityBarFill;

    void Start()
    {
        sanity = FindFirstObjectByType<Sanity>();
 
    }

    public void UpdateSanityBar()
    {
        float targetFillAmount = sanity.currentSanity / sanity.MAX_SANITY;
        sanityBarFill.fillAmount = targetFillAmount;
    }
}
