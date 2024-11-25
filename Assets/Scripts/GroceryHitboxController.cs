using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroceryHitboxController : MonoBehaviour
{
    private Sanity sanity;
    //Scene endGameScene;

    void Start()
    {
        sanity = FindFirstObjectByType<Sanity>();
        //endGameScene = SceneManager.GetSceneByName("GroceryEnd");
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Grocery Ending");
        DataManager.Instance.isDead = true;
        DataManager.Instance.SetToggleState("Grocery", true);
        sanity.Die();
        SceneManager.LoadScene("GroceryEnd");
        
    }

    
}
