using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    private HighlightInterface lastHighlighted = null;
    public GameObject target;
    public void CastCheck(RaycastHit hit)
    {
        target = hit.collider.gameObject;
        Debug.Log($"Hit: {target.name}, Tag: {target.tag}");

        if(target.gameObject.CompareTag("SanityMod"))
        {
            HighlightInterface highlightable = target.GetComponent<HighlightInterface>();
            print($"highlightable {highlightable}");
            if(highlightable != null)
            {
                if(lastHighlighted != highlightable)
                {
                    UnhighlightLastObject();
                    highlightable.Highlight(true);
                    lastHighlighted = highlightable;
                }
            }
        }
        // else
        // {
        //     Debug.Log("unhighlight");
        //     UnhighlightLastObject();
        // }
    }
    public void UnhighlightLastObject()
    {
        if(lastHighlighted != null)
        {
            lastHighlighted.Highlight(false);
            lastHighlighted = null;
        }
    }
}
