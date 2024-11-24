using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    public void Highlight(GameObject gameObject, bool isHighlighted){
        gameObject.GetComponent<MeshRenderer>().material.SetFloat("_isHighlighted", isHighlighted?1:0);
    }
}
