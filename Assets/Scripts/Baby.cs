using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Baby : MonoBehaviour, HighlightInterface
{
    public Baby Instance;
    public GameUIController uifx;
    public GameObject player;
    public Sanity playerSanity;

    #region audio
    public AudioClip babyCry;
    #endregion
    
    void Awake()
    {
        playerSanity = player.GetComponent<Sanity>();
        if (playerSanity == null) Debug.LogError($"[{gameObject}]: {nameof(playerSanity)} not found in the scene!");
        uifx = FindFirstObjectByType<GameUIController>(); // might be wrong choice of find type?
        if (uifx == null) Debug.LogError($"[{gameObject}]: {nameof(uifx)} not found in the scene!");

        StartCoroutine(RandomNumberGenerator());
        
    }
    #region interface
    public void Highlight(bool isHighlighted){
        if (uifx != null)
        {
            uifx.Highlight(gameObject, isHighlighted);
        } 
    }
    #endregion

    IEnumerator RandomNumberGenerator()
    {
        while (true)
        {
            float randomDelay = UnityEngine.Random.Range(2f, 10f);
            yield return new WaitForSeconds(randomDelay);
            EnableBabyDamage();
        }
        
    }

    void EnableBabyDamage()
    {
        if(!playerSanity.GetToggleState("babyValue")) 
        {
            AudioManager.Instance.PlaySound(babyCry);
            Debug.Log("baby mad");
            playerSanity.SetToggleState("babyValue", true);
        }
    }
}
