using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance {get; private set;}

    public int maxSanity = 100; 
    public int playerSanity;
    public sanityUI sanityBar;
    public SanityOverlay sanityOverlay;

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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoseSanity(10);
        }
    }

    void LoseSanity(int sanity)
        { 
        playerSanity -= sanity;
        sanityBar.SetSanity(playerSanity);
        }
   void Start()
    {
        sanityBar.SetMaxSanity(maxSanity);
    }
}
