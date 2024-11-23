using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class Sanity : MonoBehaviour
{
    [SerializeField] public float MAX_SANITY = 100;
    [SerializeField] public float currentSanity;

    void Start()
    {
        currentSanity = MAX_SANITY;
        InvokeRepeating("DamageSanity", 1f, 1f);
    }

    void Update()
    {
        
    }

    private Dictionary<string, (bool isActive, int value)> toggleDictionary = new Dictionary<string, (bool, int)>
    {
        {"babyValue", (false, 1)}
        //insert more cases here
    };

    public int GetTotalModifier()
    {
        int totalModifier = 0;
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
    
    
    
    public void DamageSanity()
    {
        if(currentSanity > 0)
        {
            this.currentSanity -= GetTotalModifier();
        }
        if(currentSanity <= 0)
        {
            Die();
        }
        
    }

    void Die()
    {
        Debug.Log("Insert game over.");
    }
}
