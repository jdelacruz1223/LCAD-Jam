using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public Canvas canvas;
    public GameObject cigScreen;
    public GameObject groceryScreen;
    public GameObject crashScreen;
    public GameObject sanityScreen;
    public GameObject trueScreen;

    // {"Cigarette", false},
    // {"Sanity", false},
    // {"Grocery", false},
    // {"True", false},
    bool isCigaretteEnding = DataManager.Instance.GetToggleState("Cigarette"); // returns true or false for the named ending
    bool isSanityEnding = DataManager.Instance.GetToggleState("SanityEnding");
    bool isGroceryEnding = DataManager.Instance.GetToggleState("GroceryEnding");
    bool isTrueEnding = DataManager.Instance.GetToggleState("TrueEnding");
    bool isCrashEnding = DataManager.Instance.GetToggleState("CrashEnding");
    // use these words "is*Something*Ending" to let ur functions know whether an ending is active or not.

    void Awake()
    {
        canvas = FindFirstObjectByType<Canvas>();    
    }

    private void Update()
    {
        EndGameCheck();
    }

    public void EndGameCheck()
    {
        if (isCigaretteEnding)
        {
            cigScreen.SetActive(true);
        }
        else if(isSanityEnding)
        {
            sanityScreen.SetActive(true); 
        }
        else if(isGroceryEnding)
        {
            groceryScreen.SetActive(true);
        }
        else if(isCrashEnding)
        {
            crashScreen.SetActive(true);
        }
        else
        {
            trueScreen.SetActive(true);
        }
    }
}


	






