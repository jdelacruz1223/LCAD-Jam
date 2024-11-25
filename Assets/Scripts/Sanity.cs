using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sanity : MonoBehaviour
{
    [SerializeField] public float MAX_SANITY = 100;
    [SerializeField] public float currentSanity;  // UI: currently tracks total sanity

    public SanityBar sanityBar;
    public Image sanityOverlay;

    public float sanityOverlayStartInverseAmount = .5f; //at .5, it starts the overlay at 50%. at .6, it starts the overlay at 40%. .4 starts at 40% and so on. It's the inverse!

    void Start()
    {
        currentSanity = MAX_SANITY;
        InvokeRepeating("DamageSanity", 1f, 1f);
        sanityBar = FindFirstObjectByType<SanityBar>();
    }



    #region modifiers
    private Dictionary<string, (bool isActive, float value)> toggleDictionary = new Dictionary<string, (bool, float)>
    {
        {"driveValue", (true, -1)},
        {"babyValue", (false, 3)}
        //insert more cases here
    };

    public float GetTotalModifier()
    {
        float totalModifier = 0;
        foreach(var toggle in toggleDictionary)
        {
            if(toggle.Value.isActive)
            {
                totalModifier += toggle.Value.value;
            }
        }
        return totalModifier;
    }

    public void SetToggleState(string key, bool state) // call SetToggleState("key", T/F) to change keys
    {
        if(toggleDictionary.ContainsKey(key))
        {
            toggleDictionary[key] = (state, toggleDictionary[key].value);
        }
        else
        {
            Debug.LogWarning($"{key} not found in dictionary.");
        }
    }

    public bool GetToggleState(string key)
    {
        if(toggleDictionary.TryGetValue(key, out var toggleValue))
        {
            return toggleValue.isActive;
        }
        else
        {
            Debug.LogWarning($"Key '{key}' not found.");
            return false;
        }
    }
    #endregion
    

    
    #region basic functions
    public void DamageSanity()
    {
        if(currentSanity > 0)
        {
            
            this.currentSanity -= GetTotalModifier();
            if (this.currentSanity >= MAX_SANITY)
            {
                currentSanity = MAX_SANITY;
            }

            sanityBar.UpdateSanityBar();

            Color overlayColor = Color.white;
            overlayColor.a = (1 - (currentSanity / MAX_SANITY)) - sanityOverlayStartInverseAmount;
            sanityOverlay.color = overlayColor;
        }
        if(currentSanity <= 0)
        {
            Die();
        }
        
    }
    public void Die()
    {
        Debug.Log("Insert game over.");
        SceneManager.LoadScene("SanityEnd");
        // Application.Quit();
    }
    #endregion
}
