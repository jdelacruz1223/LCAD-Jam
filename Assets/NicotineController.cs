using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NicotineController : MonoBehaviour
{
    Sanity sanity;
    Animator animator;
    [SerializeField] int sanityHealAmount;
    void Awake()
    {
        sanity = FindFirstObjectByType<Sanity>();
        if (sanity == null) Debug.LogError($"[{gameObject}]: {nameof(sanity)} not found in the scene!");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Puff activated");
            animator.SetTrigger("isSmoking");
            DataManager.Instance.cigaretteCount--;
            sanity.currentSanity += sanityHealAmount;
            if(DataManager.Instance.cigaretteCount <= 0)
            {
                CrashOut();
            }
        }
    }

    void CrashOut()
    {
        // SceneManager.LoadScene("CigEnding")
    }
}
