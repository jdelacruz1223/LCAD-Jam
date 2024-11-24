using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    public void Highlight(GameObject obj, bool isHighlighted){
        obj.GetComponent<MeshRenderer>().material.SetFloat("_isHighlighted", isHighlighted?1:0);
    }
}
