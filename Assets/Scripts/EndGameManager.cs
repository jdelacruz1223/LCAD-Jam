using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    // {"Cigarette", false},
    // {"Sanity", false},
    // {"Grocery", false},
    // {"True", false},
    bool isCigaretteEnding = DataManager.Instance.GetToggleState("Cigarette"); // returns true or false for the named ending
    bool isSanityEnding = DataManager.Instance.GetToggleState("SanityEnding");
    bool isGroceryEnding = DataManager.Instance.GetToggleState("GroceryEnding");
    bool isTrueEnding = DataManager.Instance.GetToggleState("TrueEnding");
    // use these words "is*Something*Ending" to let ur functions know whether an ending is active or not.
}

	






